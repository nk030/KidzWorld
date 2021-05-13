INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9988e602-9164-4423-867e-0aca8d2c62f5', N'admin', N'admin', N'b2717bb3-e977-4a2f-aeba-88d500d7ea44')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2b2f7d2c-8e1f-499e-872e-d29a7c65b897', N'user@cbs.com', N'USER@CBS.COM', N'user@cbs.com', N'USER@CBS.COM', 1, N'AQAAAAEAACcQAAAAEOfb/neMuvA8OdUfAWNHttFVwb++7g0rvhHfPM+lWc6xPF4sbFJcgqHlwrnr/oXYUg==', N'GKWVXHPMFI7ZSUYGDBVTX4XZETPJ45TH', N'bf99a6dc-a167-4cb5-ad97-cd3c7ced9c8d', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9370c88f-2e9f-4eef-af2a-807e6dad4f2b', N'iamadmin2@kidzworld.com', N'IAMADMIN2@KIDZWORLD.COM', N'iamadmin2@kidzworld.com', N'IAMADMIN2@KIDZWORLD.COM', 1, N'AQAAAAEAACcQAAAAEGfKebnVY6nfvtmKMA7OTMsVJkO2fPfkdPhrwD2brMocPgHgbx8UI+KWnYrHiEl6bA==', N'ZPZGHXHBEDZMUIQNFUBR25V7YITZXJ7I', N'fd276621-487f-4a90-a6b5-48f5c4681fc9', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fc19d0b1-d522-4509-8a44-c8e7b6fc545e', N'admin@cbs.com', N'ADMIN@CBS.COM', N'admin@cbs.com', N'ADMIN@CBS.COM', 1, N'AQAAAAEAACcQAAAAENd0qYnNP9yoSAu6wu+ZBAcOPpcklXfGO0n/G0H47YXIeAnFdlL7DiidwG5m3fHh8w==', N'NA4ATUFI2OI6DN4D7AE5Q2UUNUECBZ7Q', N'fb58bc69-a395-4979-8c90-53854f84a252', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ffebaff0-3a47-4951-9008-c6559292279f', N'nav13@hotmail.com', N'NAV13@HOTMAIL.COM', N'nav13@hotmail.com', N'NAV13@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEF3Y4EA3BUoqSQYKMsZfgrMkgVfD4U0IjFfiZZncysF+5jWPNeuDTuB7LJ2y89slRw==', N'3J3WMI5I26X36HDZ2HFYBOLUQ7GC7AQQ', N'4be8c114-bb34-4135-93ab-1f6865ace384', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc19d0b1-d522-4509-8a44-c8e7b6fc545e', N'9988e602-9164-4423-867e-0aca8d2c62f5')
GO
SET IDENTITY_INSERT [dbo].[KdzAges] ON 
GO
INSERT [dbo].[KdzAges] ([AgeID], [AgeName]) VALUES (1, N'3-6 Months')
GO
INSERT [dbo].[KdzAges] ([AgeID], [AgeName]) VALUES (2, N'6-9 Months')
GO
INSERT [dbo].[KdzAges] ([AgeID], [AgeName]) VALUES (3, N'9-12 Months')
GO
INSERT [dbo].[KdzAges] ([AgeID], [AgeName]) VALUES (4, N'1-4 Years')
GO
SET IDENTITY_INSERT [dbo].[KdzAges] OFF
GO
SET IDENTITY_INSERT [dbo].[Sellers] ON 
GO
INSERT [dbo].[Sellers] ([SellerID], [SellerName], [SellerAddress], [SellerContact], [ContactPerson]) VALUES (1, N'First Cry', N'Street:  3264 Smith Avenue  City:  Hamilton', N'640-902-5557', N'Jerry')
GO
INSERT [dbo].[Sellers] ([SellerID], [SellerName], [SellerAddress], [SellerContact], [ContactPerson]) VALUES (2, N'Colorz', N'Street:  3432  Smith Avenue  City:  Hamilton', N'640-915-1232', N'Peter')
GO
INSERT [dbo].[Sellers] ([SellerID], [SellerName], [SellerAddress], [SellerContact], [ContactPerson]) VALUES (3, N'Cloudtail Ptv. Ltd. ', N'Street:  4468  Jerome Avenue  City:  Raymondville  State/province/area: Texas', N' 956-248-2250', N'Ashley G Rutherford')
GO
SET IDENTITY_INSERT [dbo].[Sellers] OFF
GO
SET IDENTITY_INSERT [dbo].[KdzToys] ON 
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (1, N'Baby Rattle Toys Pack of 6', N'$199', N'
PRODUCT DESCRIPTION

These rattles are just the right size for your babys little hands to grab, hold and shake. Numerous sounds and colors will expand your baby sensory experience. Colourful patterns help develop your baby eye tracking skills. The variety in grips, shapes and tasks will assist in finger and hand-eye coordination skills.

Key Features:
>Made from safe plastic material.
>Rattles will assist in your babies early development and learning.
>Each rattle has different grips, shapes and tasks to assist in fine motor skills.
>Variety of textures will assist in tactile development of touch.', N'.jpg', 1, 1)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (2, N'Baby Blocks Set With Toy Shape Bag- 108 Pieces', N'$349.90', N'PRODUCT DESCRIPTION

Little kids love things bright and colorful. They are easily attracted to them. Colorful Learning Blocks set to make your little one playtime educational yet fun. This blocks set comes in a toy shape bag, which makes it very convenient to store the blocks and carry them from one place to another.

Key Features
>Colourful building blocks,
>Comes in a toy shape bag,
>Quality assure and safe for children,
>108 colourful blocks', N'.jpg', 4, 1)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (3, N'Wind Up Happy Monkey Toy With Drum - Pink Brown', N'$245.00', N'PRODUCT DESCRIPTION

Key Features
>Develops eye hand coordination and motor skills.
>Made from safe and non toxic material.
>Toy moves its head while playing drum.
>Wind up toy keeps kids engaged', N'.jpg', 2, 2)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (5, N'Pretend Play Sweet Shop Toy Pink - 39 Pieces', N'$1099.00', N'PRODUCT DESCRIPTION

This battery-operated luxury candy store, the sweet shop with light and sound for the kids. The toy set consists of various interesting dessert items that correspond to a two-level stand placed on a four-wheeled trolley. Develop your babys practical ability, independence, imagination, sensory capacity, eye-hand coordination ability, and the ability to identify the thing and color. Ideal for learning food groups and making healthy choices. Encourage your child to play imaginatively and creatively.

Key Features
>It includes a bowl, plays coins in cash and an ice bowl with a spoon.
>The basket has concavities, support trays, lollipop holding pits and an umbrella on top, very interesting for little girls.
>Develops social and emotional growth.
>Develops imagination and sensory capacity.
>Perfect for pretend play', N'.jpg', 4, 3)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (7, N'Musical Dinosaur Shaped Piano - Green', N'$1149.00', N'PRODUCT DESCRIPTION

Key Features:
>Different animal sound and light effect.
>Safe for toddlers to play, Non-toxic material
>Great color and beautiful design
>Educational musical toy
>Listen to various sounds', N'.jpg', 3, 3)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (8, N'Babyhug Musical Lion Keyboard - Blue', N'$119.00', N'PRODUCT DESCRIPTION

Key Features:
>Enhances memory
>Enhances social well being
>Fosters creativity
>Promotes healthier social skills
>Improves fine motor skills
>Helps boost cognitive skills', N'.jpg', 4, 2)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (9, N'Animal Shape Baby Rattle Toys- Pack of 6', N'$149.00', N'Product Description
Baby rattles help to distract the child if it is irritated. This rattle is ideal for children and their little hands. The pack consists of 6 rattles in different shapes and colors. Let them channel their abundant energy into something cute and creative. Easy to grasp and shake, this rattle develops motor skills, creativity and concentration along with cognitive thinking and auditory training.

Key features:
>Brightly colored rattles with animal shapes
>Develops a sense of hearing and rhythm
>Easy way to keep child engaged
>Develops hand and leg motion', N'.jpg', 1, 2)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (11, N'Lion Ring Stacking Toy - Multicolor', N'$99.00', N'PRODUCT DESCRIPTION

From grasping and stacking, the stacking toy has tons of fun ways for your baby to play and explore. Babies can sort and stack all the rings helping to enhance their curiosity and sense of discovery. All the pieces are made of high quality plastic. The stacking ring toy is Brightly coloured, smooth-rounded pieces help build early shape, color and size differentiation skills.

Key Features:
>Made from durable plastic material
>Brightly colored rings stimulate visual perception
>Lion face top
>Introduces babies to relative size and stacking', N'.jpg', 2, 3)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (12, N'FunBlast Animal Shaped Bath Toys-14', N'$299.00', N'Product Description
Cute and adorable, this stuffed toy can be a delightful friend to your baby for all times. Squeak fun sound when you squeeze them. Kids will never stop playing with that since it is lightweight toy for kids. Made of very bright and beautiful colour attractive for kids. Non toxic and safe material for kids. Kids can play with it freely. Rubber ducks are much thicker, softer and better quality.

Key Features 
>Bath toys make sound when squeezed.
>White hot safety disc reveals the word hot when bath water is too hot for baby.
>BPA Free, Non toxic and safe material for kids can play with it freely.', N'.jpg', 1, 3)
GO
INSERT [dbo].[KdzToys] ([ToyID], [ToyName], [Price], [ToyDescription], [Extension], [AgeID], [SellerID]) VALUES (13, N'Zest 4 Toyz Stunt Tricycle With Bump & Go Action', N'$399.00', N'PRODUCT DESCRIPTION

Zest 4 Toyz brings the stunt tricycle with 3D lights and sound a fun partner for your kids to enjoy multiple activity and boost multiple skills. The toys helps the child gain better motor skills, hand eye co-ordination, color recognition too. The stunt tricycles 3d lights grab your childs attention from the first second its turned on. It soon becomes your child Favourite toy and play for long.

Key Features:
>Features 360 degree rotation, lights and dancing toy
>Develops fine motor skills in kids
>Develops hand eye coordination', N'.jpg', 4, 1)
GO
SET IDENTITY_INSERT [dbo].[KdzToys] OFF
GO
SET IDENTITY_INSERT [dbo].[KdzSellerReview] ON 
GO
INSERT [dbo].[KdzSellerReview] ([ReviewID], [UserID], [Rating], [ReviewText], [SellerID], [ReviewDate]) VALUES (1, N'user@cbs.com', 5, N'Good One', 1, CAST(N'2021-05-06T13:05:36.7200472' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[KdzSellerReview] OFF
GO
