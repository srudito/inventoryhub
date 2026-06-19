# 📦 InventoryHub

## Overview

InventoryHub is a full-stack inventory management application developed using Blazor WebAssembly for the front-end and a Minimal API built with .NET for the back-end. The application enables users to retrieve and display product information, including structured product details and associated category data.

The project demonstrates complete integration between front-end and back-end components, effective debugging, proper JSON structuring, and performance optimization with the assistance of Microsoft Copilot.

---

## Features

The application provides the following functionality:

- Retrieval of product data from a back-end API
- Display of structured product information including category details
- Robust error handling for HTTP, timeout, and JSON-related issues
- Cross-origin communication enabled via CORS configuration
- Performance improvements through caching strategies
- Clean and maintainable architecture suitable for scaling

---

## Project Structure

The solution consists of two main components:

- **ClientApp (Blazor WebAssembly)**  
  Contains the user interface and API integration logic.

- **ServerApp (Minimal API)**  
  Provides API endpoints and handles data processing and caching.

---

## API Endpoint

The back-end exposes the following endpoint:

**GET /api/productlist**

This endpoint returns a list of products with nested category information.

Example response:

{
  "id": 1,
  "name": "Laptop",
  "price": 1200.5,
  "stock": 25,
  "category": {
    "id": 101,
    "name": "Electronics"
  }
}

---

## Setup Instructions

To run the application, follow these steps:

1. Start the back-end server:

   Navigate to the ServerApp folder and run:
   dotnet run

2. Start the front-end application:

   Navigate to the ClientApp folder and run:
   dotnet run

3. Open the application in your browser:

   https://localhost:<client-port>/fetchproducts

---

## Implementation Details

### Front-End

The Blazor front-end uses HttpClient to communicate with the API. It implements asynchronous programming using async/await to ensure responsiveness. The UI handles different states such as loading, error, and successful data retrieval.

The front-end also includes defensive programming techniques such as:
- Validation of API responses
- Handling malformed JSON
- Displaying user-friendly error messages

### Back-End

The Minimal API exposes structured JSON responses with nested objects. It is configured to allow cross-origin requests using CORS and uses in-memory caching to improve performance.

The API returns data in a consistent format to ensure smooth integration with the front-end.

---

## Performance Optimization

Performance optimization was applied to both the front-end and back-end.

On the front-end, caching was implemented using a timestamp mechanism. This prevents redundant API calls when data has already been recently retrieved, resulting in faster page loads and reduced network usage.

On the back-end, in-memory caching was implemented using IMemoryCache. This ensures that repeated API requests do not require data regeneration, reducing server workload and improving response times.

Together, these optimizations significantly enhance application efficiency and scalability.

---

## Error Handling

The application includes comprehensive error handling mechanisms, including:

- Handling of unsuccessful HTTP responses
- Handling of request timeouts
- Detection and handling of malformed JSON data
- Fallback handling for unexpected runtime errors

Errors are displayed in a user-friendly manner in the UI, while detailed logs are written to the console to assist with debugging.

---

## Microsoft Copilot Contributions

Microsoft Copilot played a significant role in accelerating development and improving code quality throughout this project. It assisted in:

- Generating initial integration code between Blazor and the API
- Identifying and resolving API route mismatches
- Suggesting correct CORS configuration to resolve cross-origin issues
- Recommending structured JSON responses with nested objects
- Enhancing error handling using structured try-catch patterns
- Introducing performance optimizations such as caching strategies
- Refactoring code to improve readability and maintainability

Copilot helped reduce development time while ensuring adherence to best practices.

---

## Challenges Faced

Several challenges were encountered during the development process:

- API route mismatches initially caused failures in data retrieval
- CORS restrictions blocked communication between front-end and back-end
- Changes in JSON structure caused deserialization errors
- Frequent API calls negatively impacted performance

These challenges were resolved with the assistance of Copilot by updating routes, configuring CORS properly, implementing structured JSON handling, and introducing caching mechanisms.

---

## Performance Testing

Performance improvements were validated using browser developer tools and console logging. The results confirmed:

- Reduced number of API calls due to caching
- Faster response times from the API
- Improved user interface responsiveness

Caching behavior was verified by observing console logs indicating whether data was fetched from the API or served from cache.

---

## Key Learnings

This project provided valuable insights into full-stack development, including:

- The importance of aligning front-end and back-end data structures
- Implementing robust error handling for real-world scenarios
- Designing APIs with scalability in mind
- The effectiveness of caching in improving performance
- Best practices for integrating client and server applications

It also demonstrated how AI tools like Copilot can significantly enhance development productivity when used effectively.

---

## Final Status

The InventoryHub application is fully functional, optimized for performance, and designed with scalability and maintainability in mind. It demonstrates successful full-stack integration, efficient error handling, and effective use of modern development tools.

---

## Reflection

For a detailed reflection on the development process and use of Microsoft Copilot, please refer to the REFLECTION.md file included in the project.

---

## Author

SULISTYO RUDITO  
Senior Application Consultant
