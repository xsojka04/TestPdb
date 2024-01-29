Shool project for subject "Distributed systems" at FIT BUT. The goal was to create program for "Beer exchange" ("Pivní burza") which can handle big amount of requests. 
"Beer exchange" is a pub in Brno where you can buy beer for current price on the exchange. The price of beer is changing based on demand and supply.

We created this project as a colletion of three programs. Two of these programs are on my GitHub profile. The first one is UI for user. It is written in PHP and not available on my GitHub profile.
Second program is a console application which is responsible for getting messages from Kafka and writing them to InfluxDB in correct order. Last program, this one, is for testing the previous programs under stress.
It creates a lot of requests in a very short amount of time and verifies the result. It is custom solution for testing a remote API. It is not using any tools for testing provided by .NET. 
The tested API also does not use any verification, but is by design correct. The goal was to test the performance of the API and not the correctness of the API.


To run the tests you need to have .NET CORE 3.1 installed. You can run the tests by command "dotnet run".
Each test is run by class Test. Each test is in folder TestCases and models for mapping requests are in folder TestModels.
