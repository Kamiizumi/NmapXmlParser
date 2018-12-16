# NmapXmlParser

A .NET Standard library for parsing [Nmap XML output](https://nmap.org/book/output-formats-xml-output.html).

## Requirements

- A framework that supports .NET Standard 1.3 or newer (see [.NET Standard Versions](https://github.com/dotnet/standard/blob/master/docs/versions.md) for details)

## Generating Classes from Schema

The classes to parse the Nmap XML output are generated from the [Nmap document type definition](https://nmap.org/book/app-nmap-dtd.html) (DTD). To prevent naming collisions the generated classes are scoped to the `NmapXmlParser` namespace.

To re-generate the classes a Visual Studio installation is required. The following steps can be used to re-generate the classes.

1. Download the latest copy of the [Nmap DTD](https://svn.nmap.org/nmap/docs/nmap.dtd) and save it to `Schemas/nmap.dtd`.
1. Convert the DTD to a XML Schema Definition (XSD):
    1. Open the downloaded DTD file in Visual Studio and go to `XML` > `Create Schema`.
    1. Remove the `xmlns` and `targetNamespace` attributes from the `xs:schema` element (line 2 of the generated XSD).
        > This is required as the XML output from Nmap is not scoped to a namespace, and the `XmlSerializer` class will throw if it expects a namespace.
    1. Save the XSD to `Schemas/nmap.xsd`.
1. Generate the C# classes from the XSD. Open the `Developer Command Prompt for VS` and run the following command from the root of this repository:
    ```bat
    xsd NmapXmlParser/Schemas/nmap.xsd /classes /language:CS /namespace:NmapXmlParser /out:NmapXmlParser/
    ```

At this point the library can be re-built to include the updated classes.
