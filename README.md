# API-Design-Approach-in .NET-Core

### Code first approach:
In general, while designing API, we first start with analyzing business requirements followed by documenting low-level design to understand the various component interaction and implement required. When implementation is completed, API documentation is generated using Swagger [Swashbuckle] (https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio). With this approach, there is very less focus on API contract, URL, request, response and return codes.

### Design First:
In this approach, we first focus on defining API contract, describing endpoints , request, response object, error codes, headers and much more using API definition editors like [swagger editor](https://editor.swagger.io/), [kong] (https://konghq.com/), [spotlight] (https://stoplight.io/design/) etc.
<Enter>
The tools will help you to design the API’s contract first before writing any code, share the document with Architects community in the organization for the review, developer can use the API definition document during implementing API. You can also use [swaggerhub] (https://swagger.io/tools/swaggerhub/) for review the API design.
The API contract can act as the central draft that keeps all your team members aligned on what your API’s objectives are, and how your API’s resources are exposed.

### Scenario:
- Let us define book store API contract using Swagger Editor. You can define the endpoints, request and response objects as follows.<Enter>
- Add detailed comments for each field in the request and response objects so that consumer of the API can understand easily.
  <Enter>
- You can define API contract in swagger editor as follows and save it as json file so that it can be refered in .NET Core API project.
   swagger editor: 
![alt text](https://github.com/srikarG81/API-Design-Approach-in-.NET-Core/blob/master/Swagger%20Editor.png "API contract")
 
``` YAML
openapi: 3.0.1
info:
  title: Book store API
  description: It includes APIs for retriving Books for given userId.
  contact:
    name: API Support
    url: 'http://bookstore.com/support'
    email: youremail.yourcompany@bt.com
  version: v1
paths:
  '/books/v1/users/{userId}/bookshelves':
    get:
      tags:
        - Book shelves
      summary: Retrives all book shelves for given user
      description: Retrives all book shelves for given user
      parameters:
        - name: userId
          description: user Id
          in: path
          required: true
          schema:
            type: string
            nullable: true
      responses:
        '200':
          description: Returns all bookshevels
          content:
            application/json:
              schema:
                type: array
                items:
                   $ref: '#/components/schemas/bookshelves'
            application/xml:
              schema:
                type: array
                items:
                   $ref: '#/components/schemas/bookshelves'
                
        '400':
          description: Bad Request
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Error'
            
        '500':
          description: Internal server error
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Error'
components:
  schemas:
    bookshelves:
      type: object
      properties:
        Id:
          type: integer
          description: shelf id
        Name:   
          type: string
          description: shelf name
    Error:
      type: object
      properties:
        code:
          type: string
          description: error code
        message:
          type: string
          description: error message


```
### Refer the Json in .NET Core API
You can generate Json document from the Swagger editor and use it in the .NET core APIs as follows.



