# Aspekt API Documentation

## Overview

This is the API documentation for the Aspekt application, which provides endpoints for managing companies, contacts, and countries.

## Company Controller

### `GET /api/company/getCompanies`
Fetch all companies with optional pagination.

- **Query Parameters**:
  - `PageNumber` (optional): The page number for pagination.
  - `PageSize` (optional): The number of results per page.

### `GET /api/company/{id}`
Fetch a company by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the company.

### `POST /api/company/createCompany`
Create a new company.

- **Request Body**:
  - `CreateCompanyRequest`: The company details to create.

### `PUT /api/company/update/{id}`
Update an existing company by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the company.
- **Request Body**:
  - `UpdateCompanyRequest`: The updated company details.

### `DELETE /api/company/delete/{id}`
Delete a company by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the company.

## Contact Controller

### `GET /api/contact/getContacts`
Fetch all contacts.

### `GET /api/contact/{id}`
Fetch a contact by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the contact.

### `POST /api/contact/createContact`
Create a new contact.

- **Request Body**:
  - `CreateContactRequest`: The contact details to create.

### `PUT /api/contact/update/{id}`
Update an existing contact by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the contact.
- **Request Body**:
  - `UpdateContactRequest`: The updated contact details.

### `DELETE /api/contact/delete/{id}`
Delete a contact by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the contact.

### `GET /api/contact/ContactWithCompanyAndCountry`
Fetch all contacts with company and country data.

### `GET /api/contact/FilterContacts`
Filter contacts by `CompanyId` and `CountryId`.

- **Query Parameters**:
  - `companyId` (optional): The company ID to filter by.
  - `countryId` (optional): The country ID to filter by.

## Country Controller

### `GET /api/country/getCountries`
Fetch all countries.

### `GET /api/country/{id}`
Fetch a country by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the country.

### `POST /api/country/createCountry`
Create a new country.

- **Request Body**:
  - `CreateCountryRequest`: The country details to create.

### `PUT /api/country/update/{id}`
Update an existing country by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the country.
- **Request Body**:
  - `UpdateCountryRequest`: The updated country details.

### `DELETE /api/country/delete/{id}`
Delete a country by its ID.

- **URL Parameters**:
  - `id`: The unique identifier of the country.

### `GET /api/country/getCompanyStatistics`
Fetch company statistics for a given country.

- **Query Parameters**:
  - `countryId`: The country ID for which to fetch company statistics.


