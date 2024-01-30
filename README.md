School project for subject "Distributed systems" at FIT BUT. The goal was to create a program for "Beer exchange" ("Pivní burza") which can handle a large number of requests. 
"Beer exchange" is a pub in Brno where you can buy beer for the current price on the exchange. The price of beer is changing based on demand and supply.

We created this project as a collection of three programs. Two of these programs are on my GitHub profile. The first one is UI for the user. It is written in PHP and not available on my GitHub profile.
The second program is a console application that is responsible for getting messages from Kafka and writing them to InfluxDB in the correct order. The last program, this one, is for testing the previous programs under stress.
It creates a lot of requests in a very short amount of time and verifies the result. It is custom solution for testing a remote API. It does not use any tools for testing provided by .NET. 
The tested API also does not use any verification but is by design correct. The goal was to test the performance of the API and not the correctness of the API.


To run the tests you need to have .NET CORE 3.1 installed. You can run the tests by command "dotnet run".
Each test is run by class Test. Each test is in the folder TestCases and models for mapping requests are in the folder TestModels.

![image](https://github.com/xsojka04/TestPdb/assets/52315948/a2209fb5-728f-4b26-9b39-de4d6e6e387c)
