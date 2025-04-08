1.TASK 1--Challenge: Maintaining a list of products available for sale (List<Products>).
        Scenario: Adding, updating, and removing products from the list.
ANS-- The ProductManager Class as the Solution

2.TASK 2--Challenge: Maintaining a list of customer orders (List<Orders>).
        Scenario: Adding new orders, updating order statuses, and removing canceled orders.
ANS-- The OrderManager Class as the Solution

3.TASK 3--Challenge: Sorting orders by order date in ascending or descending order.
          Scenario: Retrieving and displaying orders based on specific date ranges.
ANS -- The OrderManager Class as the METHODS --
Bubble Sort is used
                                 1.SortOrdersByDateAscending()
                                 2.SortOrdersByDateDescending()
                                 3.DisplayOrdersByDateRange(DateTime startDate, DateTime endDate)

4.TASK 4--Challenge: Managing product inventory with a SortedList based on product IDs.
          Scenario: Tracking the quantity in stock for each product and quickly retrieving inventory information.
ANS--The InventoryManager Class as the Solution

5.TASK5--Challenge: Ensuring that inventory is updated correctly when processing orders.
         Scenario: Decrementing product quantities in stock when orders are placed.
ANS--The InventoryManagerClass as the Method----
                            1.UpdateInventoryOnOrder(List<OrderDetails> orderDetails)

6.TASK6--Challenge: Ensuring that inventory is updated correctly when processing orders.
         Scenario: Decrementing product quantities in stock when orders are placed.
ANS---ProductManager CLass as the Method--
                               1.SearchByName(string keyword)

7.TASK7--Challenge: Preventing duplicate products from being added to the list.
          Scenario: When a product with the same name or SKU is added.
ANS-- the lOgic is implemented and if the product is duplicate It throws error
                        1.Exception name--DuplicateProductException(string message)

8.TASK8--Challenge: Managing a list of payment records for orders (List<PaymentClass>).
         Scenario: Recording and updating payment information for each order.
ANS--The Payment Manager Class as the Solution

9.TASK9--Challenge: Managing the relationship between OrderDetails and Products.
         Scenario: Ensuring that order details accurately reflect the products available in the inventory.
Ans--The logic is implemented in ------
                        1.ProductManager
                        2.InventoryManager
                        3.OrderManager



