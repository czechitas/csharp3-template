# Client-Server Model

[Wikipedia](https://en.wikipedia.org/wiki/Client-server_model)

Here's a high-level schema illustrating how `client`-`server` based applications work:

```text
+-------------------+   +-------------------+
|      Client       |   |      Server       |
+-------------------+   +-------------------+
        |                         |
        |                         |
        |         Request         |
        |  -------------------->  |
        |                         |
        |         Response        |
        |  <--------------------  |
        |                         |
```

Explanation:

1. The client is typically a user's device, such as a `web browser`, `mobile app`, or `desktop application`.

2. The server hosts the application's backend or provides services to the client. It handles requests from the client and sends back responses.

3. The client sends a request to the server, usually over a network connection. The request can include various information, such as the desired action, data, or parameters.

4. The server receives the request, processes it, and performs the necessary operations. This can involve retrieving data, executing business logic, or interacting with databases or external services.

5. The server generates a response based on the request processing. The response can include data, status codes, headers, and other relevant information.

6. The server sends the response back to the client over the network connection.

7. The client receives the response and processes it accordingly. This can involve rendering the data, updating the user interface, or performing further actions based on the response.

8. The client and server continue to communicate, exchanging requests and responses as needed to fulfill the application's functionality.

It's important to note that this is a simplified representation, and the actual communication between the client and server can involve various protocols, such as `HTTP`, `WebSocket`, or other `network protocols`. Additionally, the server may employ various technologies and frameworks to handle requests and provide services to the client.

This schema provides a general overview of the client-server interaction, where the client initiates requests, and the server responds with the requested information or performs the necessary operations.
