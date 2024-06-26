# Producer

Сервис принимает GET запросы по пути `/fileuri/` и ретранслирует его через RabbitMQ на consumer (<https://github.com/EugeneR-03/mt-file-uri-consumer>).

Пример: `http://localhost:5266/fileuri/https://download.cpuid.com/cpu-z/cpu-z_2.09-en.exe`.
