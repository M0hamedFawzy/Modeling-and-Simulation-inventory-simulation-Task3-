# Inventory Simulation System

This project simulates an inventory system for a company that sells refrigerators. The goal is to manage the inventory by reviewing the situation after a fixed number of days (N) and ordering up to a certain level (M).

## Project Details

The inventory system operates with the following parameters:
- **Review Period (N):** The number of days after which the inventory situation is reviewed.
- **Order-up-to Level (M):** The level up to which refrigerators are ordered.
- **Random Variables:**
  - Number of refrigerators demanded each day.
  - Lead time: the number of days after the order is placed with the supplier before its arrival.

For example, if the order-up-to level (M) is 11 refrigerators and the review period (N) is 5 days, and the ending inventory on day 5 is 4 refrigerators, then 7 refrigerators will be ordered from the supplier. However, if there had been a shortage of 2 refrigerators on the fifth day, then 13 would have been ordered (the first two received will be provided to the customers who placed an order and were willing to wait, called backorder).

## System Inputs

1. **Order-up-to Level (M)**
2. **Review Period (N)**
3. **Demand Probability Distribution**
4. **Lead Time Probability Distribution**
5. **Number of Days (Stopping Condition)**
6. **Beginning Inventory Quantity**
7. **First Order Arrival Time**
8. **First Order Quantity**

## System Outputs

### Simulation Table

The simulation table will have the following columns:
1. **Day**
2. **Cycle**
3. **Day within Cycle**
4. **Beginning Inventory**
5. **Random Digit for Demand**
6. **Demand**
7. **Ending Inventory**
8. **Shortage Quantity**
9. **Order Quantity**
10. **Random Digit for Lead Time**
11. **Lead Time**
12. **Days until Order Arrives**

### Performance Measures

1. **Ending Inventory Average**
2. **Shortage Quantity Average**

## Running the Simulation

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd <repository-directory>

 
