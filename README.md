# Owens

Welcome to Owens, the core loyalty application. Owens is named after [Owens Lake](https://en.wikipedia.org/wiki/Owens_Lake).

The main purpose of Owens is to serve as the primary loyalty hub to drive both clients and customers.

## Domain Terminology

Client - A client is a business that uses our services to serve customers.

Customer - An individual person that helps to drive value and revenue for our clients. Both clients and customers interact with our services-however, customers are unaware that clients use as a loyalty provider.

## Setup

## IDE

### Environment Settings

We are unable to provide a standard environment settings files for Visual Studio. But we recommend you enable auto formatting using the .editorconfig file.

Tools -> Options -> Text Editor -> Code Cleanup

Enable "Run Code Cleanup profile on Save"

In the profile only use the following lines:

"Remove unnecessary imports or usings"
"Fix analyzer warnings and errors set in EditorConfig"

### Recommended Plugins

ReSharper - We recommend using [ReSharper](https://www.jetbrains.com/resharper/) as a static analysis tool.

Fine Code Coverage - A plugin for Visual Studio, [Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage2022) will give you an easy to ready code coverage report. We require 100% branch coverage for builds to pass. This tool is helpful to give you feedback on what branches have and have not been tested.
