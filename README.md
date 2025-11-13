# Technical Exercise 

## Batch Transaction Processing

### Overview

Spend no more than 2 hours on this. 

You are tasked with improving a batch payment transaction processing API endpoint. The current implementation works but is not production ready.

Feel free to mock any external dependancies Databases, Cloud services etc.


#### Constraints

- Use the existing `IPaymentGateway` interface (do not modify it)
- The `MockPaymentGateway` simulates real world failures, do not change it
- You can add new classes, services, or dependencies as needed

### Discussion Topics

Be prepared to discuss your solution and thoughts on future changes.

### Sample Data

The `sample-data.json` file contains 10 test transactions. The mock payment gateway simulates:
- 20% random failure rate (insufficient funds, locked accounts, etc.)
- 5% timeout rate (5 second delay)
- 3% network error rate (throws exceptions)

### Notes

- This is a real world scenario, there's no single "correct" answer
- Focus on demonstrating Staff Engineer thinking: production readiness, operational excellence, system reliability
- You don't need to implement everything perfectly, be ready to discuss what you would add given more time
- Feel free to ask questions and discuss trade offs in future calls.

Please zip and send us your solution along with the .git folder (Exclude any build/binaries) 

## Presentation

Spend no more than an hour preparing this. Don't worry about the design/presentation as much as the actual content. 

Prepare a presentation on a system you’ve designed or led the design of. Walk us through how it evolved, it's impact once released, the trade offs you made, and what you’d do differently now that it’s in production. Include how you engaged with stakeholders to get buy in and challenges you faced on the way. 

