# Car Rental Mini Project

A C# Console Application implementing the five team responsibilities.

## Included
1. Database/ERD: SQL schema + Mermaid ERD.
2. Entities: Customer + abstract Vehicle + SedanVehicle + SuvVehicle + ElectricVehicle.
3. Rental Engine: RentalBooking + BookingCalculator + RentalManager.
4. Pricing: IPricingStrategy + WeeklyDiscount + VipDiscount + StudentDiscount.
5. Service/UI: RentalService + repository + notification service + interactive console menu.

## SOLID
- SRP: entities, calculation, rental management, pricing, notifications and persistence are separated.
- OCP/LSP: new Vehicle types and pricing strategies can be added without changing existing logic.
- ISP: IRentalRepository and INotificationService are separate interfaces.
- DIP: RentalService depends on IRentalRepository, INotificationService, IRentalManager and IPricingService.

## Run
Open `CarRentalMiniProject.csproj` in Visual Studio 2022 and press F5.

The project uses .NET 8.
