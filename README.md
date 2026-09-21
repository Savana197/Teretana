# Teretana

A client-server gym management system written in C# / .NET. Started as a university project for a database/OOP course, and I've kept extending it a bit after the fact — mostly the validation layer and the test suite, which weren't part of the original assignment.

The idea is simple: a WinForms app for gym staff (register members, assign trainers, sell memberships, track who's active) talking to a standalone server process over a plain TCP socket, with SQL Server (LocalDB) on the backend.

## Why a raw socket instead of a REST API

This was a deliberate constraint of the course, not something I'd necessarily pick again for a from-scratch project — but it turned out to be a decent way to actually understand what's happening under an HTTP framework instead of just consuming one. The client and server exchange a custom `Zahtev`/`Odgovor` (request/response) envelope, serialized to JSON and pushed over the socket by a small `JsonNetworkSerializer`. The server runs a loop per connected client (`ClientHandler`), reads a request, dispatches it by an `Operacija` enum, and writes back a response — no ASP.NET, no HTTP, just sockets and JSON.

## Architecture

```
Klijent (WinForms)  <-- TCP socket, JSON -->  Server (console app)
                                                     |
                                              SistemskeOperacije
                                                     |
                                                  DBBroker
                                                     |
                                              SQL Server (LocalDB)
```

Five projects: `Domen` (entities), `DBBroker` (a small generic data access layer — `Add`/`GetAll`/`GetByCondition`/`Update`/`Delete`, dispatched off an `IEntity` instance rather than generics), `SistemskeOperacije` (the actual business operations, one class per use case), `Server`, `Klijent`, plus `Testovi` for the test suite.

Every business operation goes through a small Template Method: `SOBase.ExecuteTemplate()` opens the connection, starts a transaction, runs the concrete operation, commits or rolls back on failure, and always closes the connection — so an individual operation class only has to implement `ExecuteConcreteOperation()` and not worry about the surrounding plumbing.

### Domain model

![Class diagram](docs/class-diagram.png)

### What the server can do

Grouped roughly by area, 21 operations in total:

- **Auth** — `PrijavaSO` (login by email + password)
- **Staff** — create, edit, search, deactivate (`KreirajRadnikaSO`, `PromeniRadnikaSO`, `PretraziRadnikaSO`, `DeaktivirajRadnikaSO`)
- **Members** — create, edit, search, delete (`KreirajOsobuSO`, `PromeniOsobuSO`, `PretraziOsobuSO`, `ObrisiOsobuSO`)
- **Trainers** — create, edit, list active (`KreirajTreneraSO`, `PromeniTreneraSO`, `VratiSveAktivneTrenereSO`)
- **Memberships** — create, cancel, look up a member's active membership, price calculation (with category discount), add a training item to a membership (`KreirajClanstvoSO`, `OtkaziClanstvoSO`, `VratiAktivnoClanstvoOsobeSO`, `IzracunajUkupnuCenuClanstvaSO`, `DodajStavkuClanstvaSO`)
- **Qualifications** — create, list all, assign to a staff member (`KreirajKvalifikacijuSO`, `VratiSveKvalifikacijeSO`, `DodeliKvalifikacijuRadnikuSO`)
- **Categories** — `VratiSveKategorijeSO`

## Validation

Domain classes validate themselves in their property setters rather than through data annotations — a bad value throws `ArgumentException`/`ArgumentOutOfRangeException` (or `ArgumentNullException` for `null`) right where it's assigned, both on the client (so the WinForms forms show an error message before anything is sent over the wire) and on the server (since the same setters run again when the server deserializes the incoming JSON).

One deliberate rule that took a bit of back-and-forth to get right: an **empty string is treated as "not set yet" and passes through without a format check**. That sounds backwards until you look at how the data layer is used internally — a lot of the system operations build a throwaway domain object just to read its `TableName` (e.g. `new Radnik { Ime = "", Prezime = "", ... }` in `DeaktivirajRadnikaSO`, since `Broker.Update`/`Delete` only care about the type, not the field values). If empty strings failed validation, half of those operations would throw immediately. So the rule ended up being: `null` always throws, an empty string is allowed through, and anything non-empty gets checked for real (JMBG must be exactly 13 digits, email needs an `@` and a `.`, phone numbers digits-only with a minimum length, etc.).

This does mean the domain layer alone won't stop someone from submitting a *genuinely* blank required field through the wire protocol directly — that's currently enforced by the WinForms client's own required-field check before it builds the object, not by the server independently. Listed under limitations below.

## Tests

105 xUnit tests in `Testovi/`, split into two kinds:

- **Unit tests** for the domain classes — property behavior, `TableName`/`Values`/`Join` output, and the validation rules above (both the happy path and the exceptions).
- **Integration tests** for the system operations — these hit a real LocalDB instance through the full `ExecuteTemplate()` path (open connection, transaction, real SQL, commit/rollback), not a mock. Each test seeds whatever data it needs, asserts against the actual result, and cleans up after itself in a `finally` block.

```
dotnet test
```


## What I'd do differently

Being honest about it, since this started as a course assignment and grew from there rather than being designed as a portfolio piece from day one:

- I'd reach for Entity Framework Core instead of hand-rolling the data access layer with raw ADO.NET. The generic `Broker` works, but it leans on a convention (constructing "empty" domain objects just to read their table name) that's a bit fragile and wouldn't be my first choice starting fresh.
- Required-field enforcement lives only on the client right now, not independently on the server — a client that skipped the WinForms form entirely and talked to the socket directly could still get a blank required field past the domain validation, since blank is treated as "not set" rather than "invalid." Fixing this properly means separating "object used as a plumbing detail" from "object meant to be persisted," which is a bigger refactor than I wanted to do right before defending this.
- `Članstvo.DatumIsteka` should logically come after `DatumPočetka`, but that's a cross-field check and doesn't fit cleanly into a single property setter with how the class is currently built (object initializers can set properties in any order) — left unvalidated for now rather than bolt on something half-working.
- No CI yet — `dotnet test` should run on every push, it's just not wired up.
