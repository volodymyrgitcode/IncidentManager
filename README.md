# Incident Manager API

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)

## Prerequisites

To run this application, you need to have the following installed on your system:
- .NET 8
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/) (usually included with Docker Desktop)

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/volodymyrgitcode/IncidentManager.git
   ```
   Navigate to the root directory of the project where the docker-compose.yml file is located.
   ```
   cd IncidentManager
   ```
2. Build and run the Docker containers:
   ```
   docker-compose up -d
   ```

3. The API will be available at:
   - HTTPS: https://localhost:7275

4. Access Swagger UI to explore and test the API:
   - https://localhost:7275/swagger