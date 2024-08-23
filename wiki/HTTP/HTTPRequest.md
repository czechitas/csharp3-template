# HTTP Request

HTTP requests are messages sent by the client to initiate an action on the server. They contain three parts:

- `Request Line` contains three elements: HTTP method, target URL, and HTTP version.
- `Headers` provide additional information about the request, such as the user agent, content type, and authentication credentials.
- `Body (optional)` carries additional data, if required.

Here's a schema illustrating the structure of an HTTP request:

```text
+-------------------+                +-------------------+
|       Client      |                |       Server      |
+-------------------+                +-------------------+
        |                                    |
        |          HTTP Request              |
        |  ------------------------------->  |
        |      Request Line                  |
        |      Headers                       |
        |      Body (optional)               |
        |                                    |
        |                                    |
        |          Response                  |
        |  <-------------------------------  |
        |      Status Line                   |
        |      Headers                       |
        |      Body (optional)               |
        |                                    |
```

Explanation:

1. The client initiates the HTTP request, typically a web browser or an application running on a user's device.

2. The request is composed of the request line, headers, and an optional request body. The request line specifies the HTTP method, the target URL (URI), and the HTTP version. The headers provide additional information about the request, such as the user agent, content type, and authentication credentials. The request body carries additional data, if required.

3. The request is sent from the client to the server over a network connection, usually using TCP/IP.

4. The server receives the request and processes it based on the provided information. It performs the necessary actions, such as retrieving data, executing business logic, or generating a response.

5. The server constructs an HTTP response, which includes a status line, headers, and an optional response body. The status line indicates the result of the request (e.g., 200 OK, 404 Not Found), the headers provide additional information about the response, and the response body contains the requested data or other content.

6. The response is sent back from the server to the client over the network connection.

7. The client receives the response and processes it accordingly. For example, a web browser may render HTML content, execute JavaScript, or display an error message based on the response received from the server.

This schema illustrates the flow of an HTTP request and response between a client and a server, forming the basis of communication in client-server-based applications.
