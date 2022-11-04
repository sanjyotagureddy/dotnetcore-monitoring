# dotnetcore-monitoring
Monitoring using Serilog, ElasticSearch, Kibana, Prometheus &amp; Grafana

To start docker images
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

To rebuild dockage images
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build -d
```

To stop docker images
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml down
```
