# Micro-Services Architecture (MSA)
- ### [API Gateway](api-gateway)
* ### [Access Token](access-token)

---

There are many patterns related to the microservices pattern. The Monolithic architecture is an alternative to the microservice architecture. The other patterns address issues that you will encounter when applying the microservice architecture.

![Microservices](http://microservices.io/i/PatternsRelatedToMicroservices.jpg)

- Decomposition patterns
  - **Decompose by business capability**
  - **Decompose by subdomain**
- The **Database per Service** pattern describes how each service has its own database in order to ensure loose coupling.
- The **[API Gateway](api-gateway)** pattern defines how clients access the services in a microservice architecture.
- The **Client-side Discovery** and **Server-side Discovery** patterns are used to route requests for a client to an available service instance in a microservice architecture.
- The **Messaging** and **Remote Procedure Invocation** patterns are two different ways that services can communicate.
- The **Single Service per Host** and **Multiple Services per Host** patterns are two different deployment strategies.
- Cross-cutting concerns patterns: 
  - **Microservice chassis pattern**
  - **Externalized configuration**
- Testing patterns: 
  - **Service Component Test**
  - **Service Integration Contract Test**
- **Circuit Breaker**
- **[Access Token](access-token)**
- Observability patterns:
  - **Log aggregation**
  - **Application metrics**
  - **Audit logging**
  - **Distributed tracing**
  - **Exception tracking**
  - **Health check API**
  - **Log deployments and changes**
- UI patterns:
  - **Server-side page fragment composition**
  - **Client-side UI composition**
