using System.Collections.Generic;

namespace azure_openai_sandbox
{
    public class AIPrompt
    {
        private List<string> _techUsed = new List<string>();
        private string _customer;
        private string _solutionDescription;
        private string _benefitsToCustomer;

        public AIPrompt(string customer, string solutionDescription, string benefitsToCustomer)
        {
            _customer = customer;
            _solutionDescription = solutionDescription;
            _benefitsToCustomer = benefitsToCustomer;
        }

        public void AddTechnologyUsedItem(string techUsed)
        {
            _techUsed.Add(techUsed);
        }

        public override string ToString()
        {
            return @$"
 I would like you to write a 1 page case study with 3 sections.
 Brief context, solution and benefits to customer. 
 It should include the following elements: 
 Customer: {_customer}.
 Solution: {_solutionDescription}
 Technology used: {string.Join<string>(',',_techUsed)}.
 Benefits to the customer: {_benefitsToCustomer}
 Can you elaborate on the benefits of each of the technology items used.
            ";
        }
    }
    
}

/*
Into ChatGPT via Bing ->

 I would like you to write a 1 page case study with 3 sections.
 Brief context, solution and benefits to customer. 
 It should include the following elements: 
 Customer: Michael Hill Jeweler.
 Solution: Azure integration platform for single view of the customer.
 Technology used: Azure, API Management, Service Bus, Azure container apps, private Vnet, Cosmos DB.
 What did it accomplish: Integrated data from dynamics 365, and other sub systems to provide a fast, 360 degree view of a customer record. Benefits to customer: Abstract sub system complexitites, fast view of an entire customer record including sales/orders, foundation platform for future development.

 Produced ->

 # Case Study: Azure Integration Platform for Michael Hill Jeweler

## Brief Context

Michael Hill Jeweler is a leading retailer of fine jewelry in Australia, New Zealand, Canada and the United States[^1^][1]. The company offers a wide range of products, from engagement rings and wedding bands to earrings, necklaces, bracelets and watches[^2^][2]. 

Michael Hill Jeweler wanted to improve its customer experience by providing a fast, 360-degree view of a customer record across its various systems, such as Dynamics 365 and other sub-systems. The company also wanted to create a foundation platform for future development and innovation.

## Solution

Michael Hill Jeweler chose Azure as its cloud platform to build an integration solution that would enable a single view of the customer. The solution used the following Azure services:

- Azure API Management: to expose and manage APIs for accessing customer data from different sources
- Azure Service Bus: to enable reliable and secure messaging between applications and services
- Azure Container Apps: to host microservices that perform business logic and data transformation
- Azure Private VNet: to isolate and secure the network traffic between the services
- Azure Cosmos DB: to store and query customer data in a scalable and flexible NoSQL database

The solution leveraged the benefits of Azure, such as scalability, reliability, security, performance and cost-efficiency.

## Benefits to Customer

The solution delivered the following benefits to Michael Hill Jeweler:

- Abstracted sub-system complexities: The solution hid the details of the underlying systems and provided a unified interface for accessing customer data through APIs. This simplified the integration process and reduced the dependency on sub-system vendors.
- Fast view of an entire customer record: The solution enabled a quick retrieval of customer data from various sources and presented it in a consistent format. This improved the customer experience and enabled faster decision making.
- Foundation platform for future development: The solution created a modular and extensible architecture that could support new features and functionalities in the future. The solution also leveraged the cloud capabilities of Azure, such as elasticity, automation and innovation.
 */