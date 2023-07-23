# Pet Sitting API

A simple API built in **ASP.NET Core 7.0**.

_Reference_
[**Tutorial: Create a web API with ASP.NET Core**](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio#add-a-model-class).

## Table of Contents

- [Installation](#installation)
- [Description](#description)
- [Entity Relationships](#entity-relationships)
- [Endpoints](#endpoints)
- [Usage](#usage)
- [Errors](#errors)

## Installation

Prerequisites:

- ASP.NET Core 7.0

1. Clone the repository onto your machine.
2. Build and run the project.

## Description

This API allows you to manage pets, owners, categories, and sitters for a pet sitting service.

## Entity Relationships

### Pets

Each pet belongs to a specific category. The CategoryId property in the Pet entity represents this relationship.
A pet must have one owner. The OwnerId property in the Pet entity establishes this association.
A pet can also have an optional sitter. The SitterId property in the Pet entity defines this relationship.

### Owners

An owner can have multiple pets. The OwnerId property in the Pet entity represents the foreign key linking to the Owner entity.
Each owner is associated with one or more pets through the Pets navigation property in the Owner entity.

### Categories

A category can have multiple pets. The CategoryId property in the Pet entity establishes the relationship between pets and categories.
Each category may be associated with multiple pets through the Pets navigation property in the Category entity.

### Sitters

A sitter can be assigned to multiple pets. The SitterId property in the Pet entity establishes the relationship between pets and sitters.
Each sitter can be associated with multiple pets through the Pets navigation property in the Sitter entity.

## Endpoints

Pets
| Method | Endpoint | Description |
|---|---|---|
| GET | `/pets` | Get all pets |
| GET | `/pets/{id}` | Get a specific pet by ID |
| POST | `/pets` | Create a new pet |
| PUT | `/pets/{id}` | Update an existing pet |
| DELETE | `/pets/{id}` | Delete a pet by ID |

Owners
| Method | Endpoint | Description |
|---|---|---|
| GET | `/owners` | Get all owners |
| GET | `/owners/{id}` | Get a specific owner by ID |
| POST | `/owners` | Create a new owner |
| PUT | `/owners/{id}` | Update an existing owner |
| DELETE | `/owners/{id}` | Delete an owner by ID |

Sitters
| Method | Endpoint | Description |
|---|---|---|
| GET | `/sitters` | Get all sitters |
| GET | `/sitters/{id}` | Get a specific sitter by ID |
| POST | `/sitters` | Create a new sitter |
| PUT | `/sitters/{id}` | Update an existing sitter |
| DELETE | `/sitters/{id}` | Delete a sitter by ID |

Categories
| Method | Endpoint | Description |
|---|---|---|
| GET | `/categories` | Get all categories |
| GET | `/categories/{id}` | Get a specific category by ID |
| POST | `/categories` | Create a new category |
| PUT | `/categories/{id}` | Update an existing category |
| DELETE | `/categories/{id}` | Delete a category by ID |

## Usage

Example: Get all pets

Request:

`GET /pets`

Response:

<img width="323" alt="response-petsittingapi" src="https://github.com/BiceSchembri/PetSittingAPI/assets/103190920/fff956f6-49c6-45df-a35d-1868ba820feb">

## Errors

In case of errors, the API will return appropriate HTTP status codes along with error messages.

- **400 Bad Request:** Invalid request data or parameters.
- **404 Not Found:** Resource not found.
- **500 Internal Server Error:** Unexpected server error.
