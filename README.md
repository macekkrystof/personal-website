# Personal Website 

![Azure Static Web Apps CI/CD](https://github.com/macekkrystof/personal-website/workflows/Azure%20Static%20Web%20Apps%20CI/CD/badge.svg)

Simple portfolio website powered by Blazor WebAssembly hosted in Azure Static Web Apps with Azure Functions + Storage backend. I made this as alternative for PDF CV. It's supposed to be extremely low cost solution, it's literally almost free to host. 

You can see working website here: [kmacek.cz](https://www.kmacek.czm)

# Features

  - Supports multiple language versions of website based on browser language. 
  - Responsive SPA

For now you need to write data manually to Azure Table Storage but I'm working on CMS. 

### Tech

Used technologies and projects:

* [Azure Static Web Apps] - for hosting client files and Functions
* [Azure Functions] - as part of Static Web App service, provides API that retrieves data from Azure Storage and serve them to client
* [Azure Storage] - for data and images
* [Blazor WebAssembly] - Client
* [.NET 5] - currenty RC2 but will update to official release soon
* [Font Awesome 5] - nice icons
* [startbootstrap-resume] - special thanks for this beautiful CV template, that I could modify and use
* [Bootstrap]
* [jQuery]
* [jQuery Easing]


### Todos

 - CMS for editing biography and uploading images
 - Blog

License
----

MIT

   [Bootstrap]: <https://getbootstrap.com>
   [jQuery]: <http://jquery.com>
   [Azure Static Web Apps]: <https://azure.microsoft.com/en-us/services/app-service/static/>
   [Azure Functions]: <https://azure.microsoft.com/cs-cz/services/functions/>
   [Azure Storage]: https://azure.microsoft.com/cs-cz/services/storage/
   [Blazor WebAssembly]: <https://azure.microsoft.com/en-us/services/app-service/static/>
   [.NET 5]: <https://azure.microsoft.com/en-us/services/app-service/static/>
   [Font Awesome 5]: <https://azure.microsoft.com/en-us/services/app-service/static/>
   [jQuery Easing]: <https://github.com/gdsmith/jquery.easing>
   [startbootstrap-resume]: <https://github.com/StartBootstrap/startbootstrap-resume/tree/master/src>
   [kmacek.cz]: <https://www.kmacek.cz>
   

