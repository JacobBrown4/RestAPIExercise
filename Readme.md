# About

This is an Entity Core API. It's a sample program that uses an In Memory database to showcase simple API endpoints. It has API versioning that is passed through the URI, Swagger enabled, and Serilog logger running on a one day rolling memory. (Located in C:\RestAPI\Logs).

Some things have been done to strike a balance of simple and ease of testing. Not every model has a create or list item model. Just the ones that were too tedious to work with or test repeatedly. I didn't want to bloat the project with multiple models in a single layer project. Some assumptions were made about the models and requirements of the "customer" like making address type an enum.

## Installation

Download from git hub and run in VS 2022