# Docker deployment

Make sure that the [prerequisites](dev-run-prerequisites.md) have been met before continuing

## Instances

* Integration
  - SignalR - 1 
* Data storage
  - PostgreSQL - 1
  - Elasticsearch - 1
* Observability
  - Logging - 1 ElasticSearch, 1 Kibana

## Application services

The convenience of `docker compose` makes it possible to run exactly what is needed:

Run all services:
Navigate to the root directory of the project -> WireChat\Compose\ and run `docker-compose up`

# ⚠ Caution
Remember that the elasticsearch and postgresql containers would need TSL certificates and local variables for passwords and other user information. In the docker-compose.yml file there are `env_file` sections.
Generate the following files (the names of the files are not important and you can replace them if you want, just make shure that the docker-compose.yml will point to the new names):
 - database-wirechat.dev.env 
     ```html
        < Example configuration >
     
       POSTGRES_DB: WireChatDb --> The database name
       POSTGRES_USER: WireChatAdmin --> The database user name
       POSTGRES_PASSWORD: password --> The database user password
     ```
- pgadmin.dev.env
    ```html
      PGADMIN_DEFAULT_EMAIL: admin@admin.com  --> Admin username
      PGADMIN_DEFAULT_PASSWORD: root --> Admin password
    ```
- .env
    ```html
      ELASTIC_PASSWORD=elastic123!
      ELASTIC_VERSION=8.11.3
      KIBANA_PASSWORD=kibana123!
      KIBANA_PORT=5601
      CLUSTER_NAME=search_service_cluster
      LICENSE=basic
      ELASTIC_PORT=9200
      MEMORY_LIMIT=1073741824
      KB_MEM_LIMIT=1073741824
      ENCRYPTION_KEY=c34d38b3a14956121ff2170e5030b471551370178f43e5626eec58b04a30fae2
    ```
- logstash.conf
    ```html
     < Example configuration >
     
      input {
          http {
              port => 5000
              additional_codecs => { "application/json" => "json_lines" }
          }
      }
      
      output {
          elasticsearch {
              index => "logstash-%{+YYYY.MM.dd}"
              hosts=> "${ELASTIC_HOSTS}"
              user=> "${ELASTIC_USER}"
              password=> "${ELASTIC_PASSWORD}"
              cacert=> "certs/ca/ca.crt"
          }
      }
  ```
