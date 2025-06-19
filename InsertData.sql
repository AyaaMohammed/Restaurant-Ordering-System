
INSERT INTO Restaurants (Name, Email, Phone, Rate, Image, City, Governorate, Street, Description)
VALUES 
('Zest Grill', 'info@zestgrill.com', '01012345601', 5, 'zest.jpg', 'Cairo', 'Ciza', '12 Nile Street', 'Cozy grill with top-notch steaks.'),
('PizzaLand', 'contact@pizzaland.com', '01012345602', 4, 'pizzaland.jpg', 'Alexandria', 'Alexandria', '5 Corniche Road', 'Famous for wood-fired pizza.'),
('Tasty Bites', 'hello@tastybites.com', '01012345603', 3, 'tasty.jpg', 'Giza', 'Giza', '33 Pyramids St', 'Quick bites and casual eats.'),
('Sultan Dine', 'reservations@sultandine.com', '01012345604', 5, 'sultan.jpg', 'Cairo', 'Cairo', '7 Ramses Ave', 'Fine Middle Eastern cuisine.'),
('Ocean Spoon', 'info@oceanspoon.com', '01012345605', 4, 'ocean.jpg', 'Hurghada', 'Red Sea', '88 Marina Bay', 'Seafood paradise by the sea.'),
('Green Garden', 'admin@greengarden.com', '01012345606', 4, 'garden.jpg', 'Luxor', 'Luxor', '44 Temple St', 'Vegetarian and healthy dishes.'),
('BBQ Haven', 'bbq@bbqhaven.com', '01012345607', 5, 'bbq.jpg', 'Aswan', 'Aswan', '9 Spice St', 'Best barbecue in town.'),
('Noodle House', 'team@noodlehouse.com', '01012345608', 3, 'noodle.jpg', 'Cairo', 'Cairo', '21 Asia Rd', 'Authentic Asian noodles and soups.'),
('Burger Spot', 'support@burgerspot.com', '01012345609', 4, 'burger.jpg', 'Mansoura', 'Dakahlia', '101 Tanta St', 'Casual burger joint.'),
('La Dolce', 'booking@ladolce.com', '01012345610', 5, 'ladolce.jpg', 'Alexandria', 'Alexandria', '15 Italy St', 'Italian cuisine with passion.');

INSERT INTO Menus (Name, RestaurantId)
VALUES 
('Zest Specials', 11),
('Pizza Feast', 2),
('Quick Meals', 3),
('Sultan Picks', 4),
('Seafood Catch', 5),
('Garden Picks', 6),
('BBQ Combo', 7),
('Asian Delights', 8),
('Burger Deals', 9),
('Italian Table', 10);



INSERT INTO Products (Name, Description, Price, ImageUrl, MenuId)
VALUES
('Grilled Steak', 'Juicy steak with herbs.', 120.00, 'steak.jpg', 3),
('Chicken Skewers', 'Grilled skewers with veggies.', 85.00, 'skewers.jpg', 3),
('Lamb Chops', 'Tender lamb with garlic sauce.', 130.00, 'lamb.jpg', 3),
('Grilled Salmon', 'Fresh salmon with lemon butter.', 110.00, 'salmon.jpg', 3),
('Caesar Salad', 'Crisp romaine with chicken.', 55.00, 'caesar.jpg', 3),
('Garlic Bread', 'Toasted bread with garlic butter.', 25.00, 'garlic.jpg', 3),
('Beef Burger', 'Classic grilled beef burger.', 75.00, 'burger.jpg', 3),
('Mashed Potatoes', 'Creamy mashed side.', 35.00, 'mash.jpg', 3),
('Chocolate Cake', 'Rich chocolate dessert.', 45.00, 'cake.jpg', 3),
('Lemonade', 'Freshly squeezed lemon juice.', 20.00, 'lemonade.jpg', 3);

INSERT INTO Customers (Name, Email, Phone, City, Governorate, Street)
VALUES
('Ali Hossam', 'ali1@mail.com', '0100010001', 'Cairo', 'Cairo', 'Street 1'),
('Sara Magdy', 'sara2@mail.com', '0100010002', 'Giza', 'Giza', 'Street 2'),
('Omar Khaled', 'omar3@mail.com', '0100010003', 'Alexandria', 'Alexandria', 'Street 3'),
('Nour Adel', 'nour4@mail.com', '0100010004', 'Tanta', 'Gharbia', 'Street 4'),
('Laila Sami', 'laila5@mail.com', '0100010005', 'Aswan', 'Aswan', 'Street 5'),
('Ahmed Essam', 'ahmed6@mail.com', '0100010006', 'Mansoura', 'Dakahlia', 'Street 6'),
('Mona Fathy', 'mona7@mail.com', '0100010007', 'Ismailia', 'Ismailia', 'Street 7'),
('Kareem Nabil', 'kareem8@mail.com', '0100010008', 'Luxor', 'Luxor', 'Street 8'),
('Hana Mohamed', 'hana9@mail.com', '0100010009', 'Port Said', 'Port Said', 'Street 9'),
('Tarek Saeed', 'tarek10@mail.com', '0100010010', 'Suez', 'Suez', 'Street 10');

INSERT INTO CustomerRestaurants (CustomerId, RestaurantId)
VALUES
(1, 2), (1, 3),
(2, 3), (2, 4),
(3, 4), (3, 5),
(4, 5), (4, 6),
(5, 6), (5, 7),
(6, 7), (6, 8),
(7, 8), (7, 9),
(8, 9), (8, 10),
(9, 10), (9, 11),
(10, 11), (10, 2);

INSERT INTO Reviews (Comment, Rate, ReviewDate, CustomerId, RestaurantId)
VALUES
('Excellent food and service.', 5, '2025-05-01', 1, 2),
('Good ambiance but a bit pricey.', 4, '2025-05-02', 2, 3),
('Average experience.', 3, '2025-05-03', 3, 4),
('Delicious dishes, highly recommend.', 5, '2025-05-04', 4, 5),
('Not what I expected.', 2, '2025-05-05', 5, 6),
('Very friendly staff.', 4, '2025-05-06', 6, 7),
('Food was cold.', 2, '2025-05-07', 7, 8),
('Great place for family dinner.', 5, '2025-05-08', 8, 9),
('Loved the dessert menu.', 5, '2025-05-09', 9, 10),
('Could improve the waiting time.', 3, '2025-05-10', 10, 11),

('Fantastic flavors!', 5, '2025-05-11', 1, 3),
('Too noisy.', 2, '2025-05-12', 2, 4),
('Well decorated and clean.', 4, '2025-05-13', 3, 5),
('Staff was not attentive.', 2, '2025-05-14', 4, 6),
('Loved the vegan options.', 5, '2025-05-15', 5, 7),
('Portions were small.', 3, '2025-05-16', 6, 8),
('Excellent cocktails.', 5, '2025-05-17', 7, 9),
('Good for quick lunch.', 4, '2025-05-18', 8, 10),
('Will come back again.', 5, '2025-05-19', 9, 11),
('Parking is an issue.', 3, '2025-05-20', 10, 2),

('Amazing seafood.', 5, '2025-05-21', 1, 4),
('Friendly but slow.', 3, '2025-05-22', 2, 5),
('Nice location.', 4, '2025-05-23', 3, 6),
('Food was bland.', 2, '2025-05-24', 4, 7),
('Highly recommended for celebrations.', 5, '2025-05-25', 5, 8),
('Great value for money.', 4, '2025-05-26', 6, 9),
('Too spicy for me.', 3, '2025-05-27', 7, 10),
('Cozy atmosphere.', 5, '2025-05-28', 8, 11),
('Staff very helpful.', 5, '2025-05-29', 9, 2),
('Waiting time was long.', 2, '2025-05-30', 10, 3);


INSERT INTO Orders (OrderDate, Status, CustomerId, RestaurantId)
VALUES 
('2025-05-19', 1, 1, 11),
('2025-05-19', 2, 2, 11),
('2025-05-19', 3, 3, 11),
('2025-05-19', 1, 4, 11),
('2025-05-19', 2, 5, 11),
('2025-05-19', 3, 6, 11),
('2025-05-19', 1, 7, 11),
('2025-05-19', 2, 8, 11),
('2025-05-19', 3, 9, 11),
('2025-05-19', 1, 10, 11);

INSERT INTO OrderItems (Quantity, OrderId, ProductId)
VALUES
(1, 1, 2), (2, 1, 3),
(3, 2, 4), (1, 2, 5),
(2, 3, 6), (1, 3, 7),
(1, 4, 8), (2, 4, 9),
(1, 5, 10), (3, 5, 11),
(2, 6, 2), (1, 6, 3),
(1, 7, 4), (2, 7, 5),
(3, 8, 6), (1, 8, 7),
(2, 9, 8), (1, 9, 9),
(1, 10, 10), (2, 10, 11);