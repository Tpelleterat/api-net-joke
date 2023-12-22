# api-net-joke

## Get Started

To quickly get started with the `api-net-joke` API, follow these simple steps:

1. **Install .NET 8:**
   - Ensure that you have .NET 8 installed on your machine. You can download it from the official [.NET website](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Run the API:**
   - Clone the `api-net-joke` repository to your local machine.
   - Navigate to the project directory.
   - Run the API using the following command:

     ```bash
     dotnet run
     ```

3. **Get JWT Token:**
   - After successfully running the API, you need to obtain a JWT token to authenticate your requests.
   - Use the following route to authenticate and retrieve the JWT token:

     ```
     GET /user/login
     ```

   - Include your credentials (username and password) in the request body or headers.
   - Example using curl:

     ```bash
     curl -X GET http://localhost:3000/user/login
     ```

   - The API will respond with a JWT token. Make sure to save this token for subsequent API calls.

4. **Use Bearer Token:**
   - Once you have obtained the JWT token, use it as a Bearer Token in the headers of your subsequent API calls.
   - Include the token in the `Authorization` header of your requests.
   - Example using curl:

     ```bash
     curl -X GET http://localhost:3000/your/endpoint -H "Authorization: Bearer YOUR_JWT_TOKEN"
     ```

Now you are ready to make authenticated requests to the `api-net-joke` API. Explore the available routes and have fun!