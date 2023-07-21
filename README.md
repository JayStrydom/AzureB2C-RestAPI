# Azure B2C REST API Sample - Fetch Additional User Claims

This repository contains a sample .NET C# Azure Serverless Function that demonstrates how to use Azure B2C (Business to Consumer) to call a custom API and fetch additional user claims. The Serverless Function is designed to accept requests from Azure B2C, utilizing basic authentication.

## Overview
When integrating Azure B2C with custom applications, it's often necessary to retrieve additional user information beyond the standard claims provided by B2C. This sample showcases a simple solution to call a custom API and fetch specific user claims such as userId, companyName, companyId, and roles. By utilizing Azure Serverless Function as the backend, the solution remains scalable, cost-effective, and easy to maintain.

## Features
- Azure B2C integration with custom API using basic authentication.
- Retrieval of additional user claims, including userId, companyName, companyId, and roles.
- Implementation of a .NET C# Azure Serverless Function for handling B2C requests.

## How to Use
1. Clone the repository to your local environment.
2. Configure the Azure Serverless Function to work with your Azure B2C tenant and custom API credentials.
3. Deploy the Serverless Function to Azure.
4. Ensure your B2C policies are set up to call the custom API and expect the specified additional user claims.

## Prerequisites
- Azure account with access to Azure B2C and Azure Functions.
- .NET Core SDK installed.
- Azure CLI or Azure Portal access for deployment.Getting Started

## License
This project is licensed under the MIT License. Feel free to use, modify, and distribute the code as needed.

## Contributions
Contributions to this sample are welcome! If you find any issues or have improvements to suggest, please open an issue or submit a pull request.

## Summary
By providing this sample, we hope to assist developers in efficiently integrating Azure B2C with custom applications and enhancing user claim retrieval for a seamless user experience. For any questions or feedback, please don't hesitate to contact me. Happy coding!
