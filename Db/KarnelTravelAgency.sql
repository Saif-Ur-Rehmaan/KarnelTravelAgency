USE [KarnelTravelAgency]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2/19/2024 7:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airlines]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airlines](
	[AirlineID] [int] IDENTITY(1,1) NOT NULL,
	[AirlineName] [varchar](100) NULL,
	[IATACode] [varchar](3) NULL,
	[ICAOCode] [varchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[AirlineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookedFlights]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookedFlights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlightId] [int] NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK_BookedFlights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](100) NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](max) NULL,
	[phoneNumber] [varchar](max) NULL,
	[topic] [varchar](max) NULL,
	[MessageOnTopic] [text] NULL,
	[Email] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[FlightID] [int] IDENTITY(1,1) NOT NULL,
	[AirlineID] [int] NULL,
	[FlightNumber] [varchar](10) NULL,
	[DepartureAirportCode] [varchar](3) NULL,
	[ArrivalAirportCode] [varchar](3) NULL,
	[DepartureDateTime] [datetime] NULL,
	[ArrivalDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guests](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
	[Rating] [decimal](3, 2) NULL,
	[HotelImg] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewslettersSubscription]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewslettersSubscription](
	[Id] [int] NOT NULL,
	[Email] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageActivities]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageActivities](
	[PackageActivityID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NULL,
	[ActivityID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageItems]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageItems](
	[PackageItemID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NULL,
	[ItemID] [int] NULL,
	[ItemType] [varchar](50) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageMeals]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageMeals](
	[PackageMealID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NULL,
	[MenuItemID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageMealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[PackageID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [varchar](100) NULL,
	[Description] [text] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageServices]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageServices](
	[PackageServiceID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NULL,
	[ServiceID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NULL,
	[RoomID] [int] NULL,
	[GuestID] [int] NULL,
	[CheckInDate] [date] NULL,
	[CheckOutDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationServices]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationServices](
	[ReservationServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[ServiceID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResortActivities]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResortActivities](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityName] [varchar](100) NULL,
	[Description] [text] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResortGuests]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResortGuests](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResortReservationActivities]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResortReservationActivities](
	[ReservationActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[ActivityID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResortReservations]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResortReservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[ResortID] [int] NULL,
	[RoomID] [int] NULL,
	[GuestID] [int] NULL,
	[CheckInDate] [date] NULL,
	[CheckOutDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResortRooms]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResortRooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[ResortID] [int] NULL,
	[RoomNumber] [varchar](10) NULL,
	[RoomType] [varchar](50) NULL,
	[Capacity] [int] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resorts]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resorts](
	[ResortID] [int] IDENTITY(1,1) NOT NULL,
	[ResortName] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
	[Rating] [decimal](3, 2) NULL,
	[ResortImg] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResortID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantCustomers]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantCustomers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantMenuItems]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantMenuItems](
	[MenuItemID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantID] [int] NULL,
	[ItemName] [varchar](100) NULL,
	[Category] [varchar](50) NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantOrderItems]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantOrderItems](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[MenuItemID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantPayments]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPayments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[PaymentDate] [date] NULL,
	[Amount] [decimal](10, 2) NULL,
	[PaymentMethod] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantReservations]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantReservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantID] [int] NULL,
	[TableID] [int] NULL,
	[CustomerID] [int] NULL,
	[ReservationDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[RestaurantID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
	[CuisineType] [varchar](50) NULL,
	[Rating] [decimal](3, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NULL,
	[RoomNumber] [varchar](10) NULL,
	[RoomType] [varchar](50) NULL,
	[Capacity] [int] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[RouteID] [int] IDENTITY(1,1) NOT NULL,
	[DepartureCity] [varchar](50) NULL,
	[ArrivalCity] [varchar](50) NULL,
	[DistanceInKm] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[RouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](100) NULL,
	[Description] [text] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NULL,
	[CountryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantID] [int] NULL,
	[TableNumber] [int] NULL,
	[Capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportCompanies]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportCompanies](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[RegistrationNumber] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[TripID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[RouteID] [int] NULL,
	[DepartureDateTime] [datetime] NULL,
	[ArrivalDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2/19/2024 7:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[VehicleType] [varchar](50) NULL,
	[RegistrationPlate] [varchar](20) NULL,
	[Capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([AdminID], [UserName], [Password], [RoleID]) VALUES (1, N'admin1', N'password123', 1)
INSERT [dbo].[Admins] ([AdminID], [UserName], [Password], [RoleID]) VALUES (2, N'admin2', N'securepwd', 1)
INSERT [dbo].[Admins] ([AdminID], [UserName], [Password], [RoleID]) VALUES (3, N'admin3', N'adminpass', 1)
INSERT [dbo].[Admins] ([AdminID], [UserName], [Password], [RoleID]) VALUES (4, N'admin4', N'admin123', 1)
INSERT [dbo].[Admins] ([AdminID], [UserName], [Password], [RoleID]) VALUES (5, N'admin5', N'password', 1)
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Airlines] ON 

INSERT [dbo].[Airlines] ([AirlineID], [AirlineName], [IATACode], [ICAOCode]) VALUES (1, N'Delta Airlines', N'DL', N'DAL')
INSERT [dbo].[Airlines] ([AirlineID], [AirlineName], [IATACode], [ICAOCode]) VALUES (2, N'British Airways', N'BA', N'BAW')
INSERT [dbo].[Airlines] ([AirlineID], [AirlineName], [IATACode], [ICAOCode]) VALUES (3, N'Air Canada', N'AC', N'ACA')
INSERT [dbo].[Airlines] ([AirlineID], [AirlineName], [IATACode], [ICAOCode]) VALUES (4, N'Qantas', N'QF', N'QFA')
INSERT [dbo].[Airlines] ([AirlineID], [AirlineName], [IATACode], [ICAOCode]) VALUES (5, N'Lufthansa', N'LH', N'DLH')
SET IDENTITY_INSERT [dbo].[Airlines] OFF
GO
SET IDENTITY_INSERT [dbo].[BookedFlights] ON 

INSERT [dbo].[BookedFlights] ([Id], [FlightId], [userId]) VALUES (1, 1, 1007)
INSERT [dbo].[BookedFlights] ([Id], [FlightId], [userId]) VALUES (2, 1, 1009)
INSERT [dbo].[BookedFlights] ([Id], [FlightId], [userId]) VALUES (3, 1, 1010)
SET IDENTITY_INSERT [dbo].[BookedFlights] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityID], [CityName], [StateID], [CountryID]) VALUES (1, N'Los Angeles', 1, 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID], [CountryID]) VALUES (2, N'New York City', 2, 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID], [CountryID]) VALUES (3, N'Manchester', 3, 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID], [CountryID]) VALUES (4, N'Toronto', 4, 3)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID], [CountryID]) VALUES (5, N'Brisbane', 5, 4)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'United States')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'United Kingdom')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (3, N'Canada')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (4, N'Australia')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (5, N'Germany')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 

INSERT [dbo].[Flights] ([FlightID], [AirlineID], [FlightNumber], [DepartureAirportCode], [ArrivalAirportCode], [DepartureDateTime], [ArrivalDateTime]) VALUES (1, 1, N'DL123', N'LAX', N'JFK', CAST(N'2024-01-20T12:00:00.000' AS DateTime), CAST(N'2024-01-20T18:00:00.000' AS DateTime))
INSERT [dbo].[Flights] ([FlightID], [AirlineID], [FlightNumber], [DepartureAirportCode], [ArrivalAirportCode], [DepartureDateTime], [ArrivalDateTime]) VALUES (2, 2, N'BA456', N'LHR', N'YYZ', CAST(N'2024-01-21T10:30:00.000' AS DateTime), CAST(N'2024-01-21T15:45:00.000' AS DateTime))
INSERT [dbo].[Flights] ([FlightID], [AirlineID], [FlightNumber], [DepartureAirportCode], [ArrivalAirportCode], [DepartureDateTime], [ArrivalDateTime]) VALUES (3, 3, N'AC789', N'YYZ', N'YVR', CAST(N'2024-01-22T08:15:00.000' AS DateTime), CAST(N'2024-01-22T11:30:00.000' AS DateTime))
INSERT [dbo].[Flights] ([FlightID], [AirlineID], [FlightNumber], [DepartureAirportCode], [ArrivalAirportCode], [DepartureDateTime], [ArrivalDateTime]) VALUES (4, 4, N'QF101', N'BNE', N'SYD', CAST(N'2024-01-23T14:45:00.000' AS DateTime), CAST(N'2024-01-23T16:30:00.000' AS DateTime))
INSERT [dbo].[Flights] ([FlightID], [AirlineID], [FlightNumber], [DepartureAirportCode], [ArrivalAirportCode], [DepartureDateTime], [ArrivalDateTime]) VALUES (5, 5, N'LH234', N'FRA', N'MUC', CAST(N'2024-01-24T13:00:00.000' AS DateTime), CAST(N'2024-01-24T14:15:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
SET IDENTITY_INSERT [dbo].[Guests] ON 

INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (1, N'John', N'Doe', N'john.doe@email.com', N'555-1234')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (2, N'Jane', N'Smith', N'jane.smith@email.com', N'555-5678')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (3, N'Michael', N'Johnson', N'michael.j@email.com', N'555-9876')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (4, N'Emily', N'White', N'emily.white@email.com', N'555-6543')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (5, N'David', N'Brown', N'david.b@email.com', N'555-8765')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (7, N'aa', N'aa', N'aa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (8, N'aa', N'a', N'aa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (9, N'aa', N'a', N'aa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (10, N'aa', N'a', N'aa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (11, N'aaaa', N'aa', N'aaaa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (12, N'aaaa', N'aa', N'aaaa', N'11111111111111')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (13, N'a', N'a', N'a', N'a')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (14, N'a', N'a', N'a', N'a')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (15, N'a', N'a', N'a', N'a')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (16, N'11', N'11', N'111', N'11')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (17, N'aa', N'sa', N'a@g.c', N'03358847952')
INSERT [dbo].[Guests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (18, N'aa', N'aa', N'a@g.c', N'02258847698')
SET IDENTITY_INSERT [dbo].[Guests] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([HotelID], [HotelName], [Location], [Rating], [HotelImg]) VALUES (1, N'Luxury Hotel1', N'Downtown, Los Angeles', CAST(4.50 AS Decimal(3, 2)), N'img/Hotel/h1.jpg')
INSERT [dbo].[Hotels] ([HotelID], [HotelName], [Location], [Rating], [HotelImg]) VALUES (2, N'City View Hotel', N'Midtown, New York City', CAST(4.00 AS Decimal(3, 2)), N'img/Hotel/h2.jpg')
INSERT [dbo].[Hotels] ([HotelID], [HotelName], [Location], [Rating], [HotelImg]) VALUES (3, N'Grand Hotel', N'Central London', CAST(4.80 AS Decimal(3, 2)), N'img/Hotel/h3.jpg')
INSERT [dbo].[Hotels] ([HotelID], [HotelName], [Location], [Rating], [HotelImg]) VALUES (4, N'Maple Leaf Inn', N'Downtown Toronto', CAST(4.20 AS Decimal(3, 2)), N'img/Hotel/h4.jpg')
INSERT [dbo].[Hotels] ([HotelID], [HotelName], [Location], [Rating], [HotelImg]) VALUES (5, N'Sunshine Resort', N'Gold Coast, Brisbane', CAST(4.70 AS Decimal(3, 2)), N'img/Hotel/h5.jpg')
SET IDENTITY_INSERT [dbo].[Hotels] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageActivities] ON 

INSERT [dbo].[PackageActivities] ([PackageActivityID], [PackageID], [ActivityID], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[PackageActivities] ([PackageActivityID], [PackageID], [ActivityID], [Quantity]) VALUES (2, 2, 2, 1)
INSERT [dbo].[PackageActivities] ([PackageActivityID], [PackageID], [ActivityID], [Quantity]) VALUES (3, 3, 3, 3)
INSERT [dbo].[PackageActivities] ([PackageActivityID], [PackageID], [ActivityID], [Quantity]) VALUES (4, 4, 4, 1)
INSERT [dbo].[PackageActivities] ([PackageActivityID], [PackageID], [ActivityID], [Quantity]) VALUES (5, 5, 5, 2)
SET IDENTITY_INSERT [dbo].[PackageActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageItems] ON 

INSERT [dbo].[PackageItems] ([PackageItemID], [PackageID], [ItemID], [ItemType], [Quantity]) VALUES (1, 1, 1, N'Activity', 2)
INSERT [dbo].[PackageItems] ([PackageItemID], [PackageID], [ItemID], [ItemType], [Quantity]) VALUES (2, 2, 2, N'Service', 1)
INSERT [dbo].[PackageItems] ([PackageItemID], [PackageID], [ItemID], [ItemType], [Quantity]) VALUES (3, 3, 3, N'Activity', 3)
INSERT [dbo].[PackageItems] ([PackageItemID], [PackageID], [ItemID], [ItemType], [Quantity]) VALUES (4, 4, 4, N'Service', 2)
INSERT [dbo].[PackageItems] ([PackageItemID], [PackageID], [ItemID], [ItemType], [Quantity]) VALUES (5, 5, 5, N'Activity', 1)
SET IDENTITY_INSERT [dbo].[PackageItems] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageMeals] ON 

INSERT [dbo].[PackageMeals] ([PackageMealID], [PackageID], [MenuItemID], [Quantity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[PackageMeals] ([PackageMealID], [PackageID], [MenuItemID], [Quantity]) VALUES (2, 2, 2, 2)
INSERT [dbo].[PackageMeals] ([PackageMealID], [PackageID], [MenuItemID], [Quantity]) VALUES (3, 3, 3, 1)
INSERT [dbo].[PackageMeals] ([PackageMealID], [PackageID], [MenuItemID], [Quantity]) VALUES (4, 4, 4, 3)
INSERT [dbo].[PackageMeals] ([PackageMealID], [PackageID], [MenuItemID], [Quantity]) VALUES (5, 5, 5, 2)
SET IDENTITY_INSERT [dbo].[PackageMeals] OFF
GO
SET IDENTITY_INSERT [dbo].[Packages] ON 

INSERT [dbo].[Packages] ([PackageID], [PackageName], [Description], [Price]) VALUES (1, N'Adventure Package', N'Includes outdoor activities', CAST(200.00 AS Decimal(10, 2)))
INSERT [dbo].[Packages] ([PackageID], [PackageName], [Description], [Price]) VALUES (2, N'Relaxation Package', N'Spa treatments and leisure', CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[Packages] ([PackageID], [PackageName], [Description], [Price]) VALUES (3, N'Culinary Package', N'Fine dining experiences', CAST(180.00 AS Decimal(10, 2)))
INSERT [dbo].[Packages] ([PackageID], [PackageName], [Description], [Price]) VALUES (4, N'Family Fun Package', N'Activities for all ages', CAST(250.00 AS Decimal(10, 2)))
INSERT [dbo].[Packages] ([PackageID], [PackageName], [Description], [Price]) VALUES (5, N'Romantic Getaway', N'Perfect for couples', CAST(300.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Packages] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageServices] ON 

INSERT [dbo].[PackageServices] ([PackageServiceID], [PackageID], [ServiceID], [Quantity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[PackageServices] ([PackageServiceID], [PackageID], [ServiceID], [Quantity]) VALUES (2, 2, 2, 2)
INSERT [dbo].[PackageServices] ([PackageServiceID], [PackageID], [ServiceID], [Quantity]) VALUES (3, 3, 3, 1)
INSERT [dbo].[PackageServices] ([PackageServiceID], [PackageID], [ServiceID], [Quantity]) VALUES (4, 4, 4, 3)
INSERT [dbo].[PackageServices] ([PackageServiceID], [PackageID], [ServiceID], [Quantity]) VALUES (5, 5, 5, 2)
SET IDENTITY_INSERT [dbo].[PackageServices] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (1, 1, 1, 1, CAST(N'2024-02-01' AS Date), CAST(N'2024-02-05' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (2, 2, 2, 2, CAST(N'2024-02-10' AS Date), CAST(N'2024-02-15' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (3, 3, 3, 3, CAST(N'2024-02-20' AS Date), CAST(N'2024-02-25' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (4, 4, 4, 4, CAST(N'2024-03-01' AS Date), CAST(N'2024-03-07' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (5, 5, 5, 5, CAST(N'2024-03-15' AS Date), CAST(N'2024-03-20' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (18, 2, 2, 10, CAST(N'2024-03-01' AS Date), CAST(N'2024-02-27' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (19, 2, 2, 11, CAST(N'2024-03-01' AS Date), CAST(N'2024-02-27' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (20, 2, 2, 12, CAST(N'2024-03-01' AS Date), CAST(N'2024-02-27' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (21, 1, 1, 15, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (22, 2, 2, 16, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (23, 1, 1, 17, CAST(N'2024-02-17' AS Date), CAST(N'2024-02-20' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [HotelID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (24, 1, 1, 18, CAST(N'2024-02-28' AS Date), CAST(N'2024-03-14' AS Date))
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[ReservationServices] ON 

INSERT [dbo].[ReservationServices] ([ReservationServiceID], [ReservationID], [ServiceID], [Quantity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[ReservationServices] ([ReservationServiceID], [ReservationID], [ServiceID], [Quantity]) VALUES (2, 2, 2, 2)
INSERT [dbo].[ReservationServices] ([ReservationServiceID], [ReservationID], [ServiceID], [Quantity]) VALUES (3, 3, 3, 1)
INSERT [dbo].[ReservationServices] ([ReservationServiceID], [ReservationID], [ServiceID], [Quantity]) VALUES (4, 4, 4, 3)
INSERT [dbo].[ReservationServices] ([ReservationServiceID], [ReservationID], [ServiceID], [Quantity]) VALUES (5, 5, 5, 2)
SET IDENTITY_INSERT [dbo].[ReservationServices] OFF
GO
SET IDENTITY_INSERT [dbo].[ResortActivities] ON 

INSERT [dbo].[ResortActivities] ([ActivityID], [ActivityName], [Description], [Price]) VALUES (1, N'Scuba Diving', N'Explore the underwater world', CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortActivities] ([ActivityID], [ActivityName], [Description], [Price]) VALUES (2, N'Spa Day', N'Relax with a rejuvenating spa treatment', CAST(80.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortActivities] ([ActivityID], [ActivityName], [Description], [Price]) VALUES (3, N'Hiking Tour', N'Guided hiking adventure', CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortActivities] ([ActivityID], [ActivityName], [Description], [Price]) VALUES (4, N'Sailing Excursion', N'Sail along the coastline', CAST(60.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortActivities] ([ActivityID], [ActivityName], [Description], [Price]) VALUES (5, N'Beach Yoga', N'Morning yoga on the beach', CAST(20.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ResortActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[ResortGuests] ON 

INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (1, N'Emma', N'Davis', N'emma.d@email.com', N'555-2345')
INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (2, N'Daniel', N'Miller', N'daniel.m@email.com', N'555-6789')
INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (3, N'Olivia', N'Wilson', N'olivia.w@email.com', N'555-8765')
INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (4, N'James', N'Moore', N'james.m@email.com', N'555-5432')
INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (5, N'Ava', N'Taylor', N'ava.t@email.com', N'555-9876')
INSERT [dbo].[ResortGuests] ([GuestID], [FirstName], [LastName], [Email], [Phone]) VALUES (6, N'a', N'a', N'a', N'aa')
SET IDENTITY_INSERT [dbo].[ResortGuests] OFF
GO
SET IDENTITY_INSERT [dbo].[ResortReservationActivities] ON 

INSERT [dbo].[ResortReservationActivities] ([ReservationActivityID], [ReservationID], [ActivityID], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[ResortReservationActivities] ([ReservationActivityID], [ReservationID], [ActivityID], [Quantity]) VALUES (2, 2, 2, 1)
INSERT [dbo].[ResortReservationActivities] ([ReservationActivityID], [ReservationID], [ActivityID], [Quantity]) VALUES (3, 3, 3, 3)
INSERT [dbo].[ResortReservationActivities] ([ReservationActivityID], [ReservationID], [ActivityID], [Quantity]) VALUES (4, 4, 4, 1)
INSERT [dbo].[ResortReservationActivities] ([ReservationActivityID], [ReservationID], [ActivityID], [Quantity]) VALUES (5, 5, 5, 2)
SET IDENTITY_INSERT [dbo].[ResortReservationActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[ResortReservations] ON 

INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (1, 1, 1, 1, CAST(N'2024-04-01' AS Date), CAST(N'2024-04-05' AS Date))
INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (2, 2, 2, 2, CAST(N'2024-04-10' AS Date), CAST(N'2024-04-15' AS Date))
INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (3, 3, 3, 3, CAST(N'2024-04-20' AS Date), CAST(N'2024-04-25' AS Date))
INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (4, 4, 4, 4, CAST(N'2024-05-01' AS Date), CAST(N'2024-05-07' AS Date))
INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (5, 5, 5, 5, CAST(N'2024-05-15' AS Date), CAST(N'2024-05-20' AS Date))
INSERT [dbo].[ResortReservations] ([ReservationID], [ResortID], [RoomID], [GuestID], [CheckInDate], [CheckOutDate]) VALUES (6, 1, 1, 6, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[ResortReservations] OFF
GO
SET IDENTITY_INSERT [dbo].[ResortRooms] ON 

INSERT [dbo].[ResortRooms] ([RoomID], [ResortID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (1, 1, N'101', N'Ocean View Suite', 2, CAST(350.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortRooms] ([RoomID], [ResortID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (2, 2, N'201', N'Mountain Lodge Room', 2, CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortRooms] ([RoomID], [ResortID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (3, 3, N'301', N'Beachfront Villa', 4, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortRooms] ([RoomID], [ResortID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (4, 4, N'102', N'Alpine Chalet', 2, CAST(400.00 AS Decimal(10, 2)))
INSERT [dbo].[ResortRooms] ([RoomID], [ResortID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (5, 5, N'501', N'Overwater Bungalow', 2, CAST(450.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ResortRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Resorts] ON 

INSERT [dbo].[Resorts] ([ResortID], [ResortName], [Location], [Rating], [ResortImg]) VALUES (1, N'Paradise Resort', N'Maui, Hawaii', CAST(4.70 AS Decimal(3, 2)), N'img/Resort/r1.jpg')
INSERT [dbo].[Resorts] ([ResortID], [ResortName], [Location], [Rating], [ResortImg]) VALUES (2, N'Mountain View Lodge', N'Aspen, Colorado', CAST(4.50 AS Decimal(3, 2)), N'img/Resort/r2.jpg')
INSERT [dbo].[Resorts] ([ResortID], [ResortName], [Location], [Rating], [ResortImg]) VALUES (3, N'Sunny Shores Retreat', N'Cancun, Mexico', CAST(4.80 AS Decimal(3, 2)), N'img/Resort/r3.jpg')
INSERT [dbo].[Resorts] ([ResortID], [ResortName], [Location], [Rating], [ResortImg]) VALUES (4, N'Alpine Escape Resort', N'Swiss Alps', CAST(4.60 AS Decimal(3, 2)), N'img/Resort/r4.jpg')
INSERT [dbo].[Resorts] ([ResortID], [ResortName], [Location], [Rating], [ResortImg]) VALUES (5, N'Tropical Oasis Resort', N'Bora Bora', CAST(4.90 AS Decimal(3, 2)), N'img/Resort/r5.jpg')
SET IDENTITY_INSERT [dbo].[Resorts] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantCustomers] ON 

INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (1, N'Sophia', N'Jones', N'sophia.j@email.com', N'555-4321')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (2, N'Liam', N'Anderson', N'liam.a@email.com', N'555-7890')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (3, N'Isabella', N'Brown', N'isabella.b@email.com', N'555-6543')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (4, N'Mason', N'Taylor', N'mason.t@email.com', N'555-8901')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (5, N'Olivia', N'Johnson', N'olivia.j@email.com', N'555-5678')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (6, N'zz', N'zzxz', N's@g.k', N'111111111111111')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (7, N'a', N'a', N'a@h.k', N'a')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (8, N'a', N'a', N's@g.k', N'a')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (9, N'a', N'a', N's@g.k', N'1111')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (10, N'sa', N'as', N'sa@g.c', N'03378847598')
INSERT [dbo].[RestaurantCustomers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (11, N'sa', N'as', N'sa@g.c', N'03378847598')
SET IDENTITY_INSERT [dbo].[RestaurantCustomers] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantMenuItems] ON 

INSERT [dbo].[RestaurantMenuItems] ([MenuItemID], [RestaurantID], [ItemName], [Category], [Price]) VALUES (1, 1, N'Margherita Pizza', N'Pizza', CAST(12.50 AS Decimal(10, 2)))
INSERT [dbo].[RestaurantMenuItems] ([MenuItemID], [RestaurantID], [ItemName], [Category], [Price]) VALUES (2, 1, N'Fish and Chips', N'Seafood', CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[RestaurantMenuItems] ([MenuItemID], [RestaurantID], [ItemName], [Category], [Price]) VALUES (3, 1, N'Sashimi Platter', N'Sushi', CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[RestaurantMenuItems] ([MenuItemID], [RestaurantID], [ItemName], [Category], [Price]) VALUES (4, 2, N'Coq au Vin', N'Main Course', CAST(18.00 AS Decimal(10, 2)))
INSERT [dbo].[RestaurantMenuItems] ([MenuItemID], [RestaurantID], [ItemName], [Category], [Price]) VALUES (5, 5, N'Chicken Tikka Masala', N'Curry', CAST(14.50 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[RestaurantMenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantOrderItems] ON 

INSERT [dbo].[RestaurantOrderItems] ([OrderItemID], [ReservationID], [MenuItemID], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[RestaurantOrderItems] ([OrderItemID], [ReservationID], [MenuItemID], [Quantity]) VALUES (2, 2, 2, 1)
INSERT [dbo].[RestaurantOrderItems] ([OrderItemID], [ReservationID], [MenuItemID], [Quantity]) VALUES (3, 3, 3, 1)
INSERT [dbo].[RestaurantOrderItems] ([OrderItemID], [ReservationID], [MenuItemID], [Quantity]) VALUES (4, 4, 4, 2)
INSERT [dbo].[RestaurantOrderItems] ([OrderItemID], [ReservationID], [MenuItemID], [Quantity]) VALUES (5, 5, 5, 3)
SET IDENTITY_INSERT [dbo].[RestaurantOrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantPayments] ON 

INSERT [dbo].[RestaurantPayments] ([PaymentID], [ReservationID], [PaymentDate], [Amount], [PaymentMethod]) VALUES (1, 1, CAST(N'2024-06-01' AS Date), CAST(25.00 AS Decimal(10, 2)), N'Credit Card')
INSERT [dbo].[RestaurantPayments] ([PaymentID], [ReservationID], [PaymentDate], [Amount], [PaymentMethod]) VALUES (2, 2, CAST(N'2024-06-05' AS Date), CAST(32.50 AS Decimal(10, 2)), N'Cash')
INSERT [dbo].[RestaurantPayments] ([PaymentID], [ReservationID], [PaymentDate], [Amount], [PaymentMethod]) VALUES (3, 3, CAST(N'2024-06-10' AS Date), CAST(45.00 AS Decimal(10, 2)), N'Credit Card')
INSERT [dbo].[RestaurantPayments] ([PaymentID], [ReservationID], [PaymentDate], [Amount], [PaymentMethod]) VALUES (4, 4, CAST(N'2024-06-15' AS Date), CAST(36.00 AS Decimal(10, 2)), N'Cash')
INSERT [dbo].[RestaurantPayments] ([PaymentID], [ReservationID], [PaymentDate], [Amount], [PaymentMethod]) VALUES (5, 5, CAST(N'2024-06-20' AS Date), CAST(59.50 AS Decimal(10, 2)), N'Credit Card')
SET IDENTITY_INSERT [dbo].[RestaurantPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantReservations] ON 

INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (1, 1, 1, 1, CAST(N'2024-06-01T18:30:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (2, 2, 2, 2, CAST(N'2024-06-05T20:00:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (3, 3, 3, 3, CAST(N'2024-06-10T12:15:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (4, 4, 4, 4, CAST(N'2024-06-15T19:45:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (5, 5, 5, 5, CAST(N'2024-06-20T14:30:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (7, 1, 1, 7, CAST(N'2024-12-12T00:55:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (8, 1, 1, 8, CAST(N'2024-02-14T12:38:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (9, 1, 1, 9, CAST(N'2024-02-14T14:38:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (10, 1, 1, 10, CAST(N'2024-02-23T10:53:00.000' AS DateTime))
INSERT [dbo].[RestaurantReservations] ([ReservationID], [RestaurantID], [TableID], [CustomerID], [ReservationDateTime]) VALUES (11, 1, 1, 11, CAST(N'2024-02-23T10:53:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[RestaurantReservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurants] ON 

INSERT [dbo].[Restaurants] ([RestaurantID], [RestaurantName], [Location], [CuisineType], [Rating]) VALUES (1, N'Casa Italiana', N'Little Italy, New York City', N'Italian', CAST(4.60 AS Decimal(3, 2)))
INSERT [dbo].[Restaurants] ([RestaurantID], [RestaurantName], [Location], [CuisineType], [Rating]) VALUES (2, N'The Royal Pub', N'Westminster, London', N'British Pub', CAST(4.30 AS Decimal(3, 2)))
INSERT [dbo].[Restaurants] ([RestaurantID], [RestaurantName], [Location], [CuisineType], [Rating]) VALUES (3, N'Sushi Sensation', N'Downtown Tokyo', N'Japanese', CAST(4.90 AS Decimal(3, 2)))
INSERT [dbo].[Restaurants] ([RestaurantID], [RestaurantName], [Location], [CuisineType], [Rating]) VALUES (4, N'Café Parisien', N'Le Marais, Paris', N'French', CAST(4.70 AS Decimal(3, 2)))
INSERT [dbo].[Restaurants] ([RestaurantID], [RestaurantName], [Location], [CuisineType], [Rating]) VALUES (5, N'Spice Garden', N'Mumbai, India', N'Indian', CAST(4.50 AS Decimal(3, 2)))
SET IDENTITY_INSERT [dbo].[Restaurants] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (5, N'Customer')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (4, N'Employee')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Manager')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomID], [HotelID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (1, 1, N'101', N'Deluxe', 2, CAST(200.00 AS Decimal(10, 2)))
INSERT [dbo].[Rooms] ([RoomID], [HotelID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (2, 2, N'202', N'Standard', 2, CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[Rooms] ([RoomID], [HotelID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (3, 2, N'301', N'Suite', 3, CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[Rooms] ([RoomID], [HotelID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (4, 4, N'102', N'Executive', 2, CAST(180.00 AS Decimal(10, 2)))
INSERT [dbo].[Rooms] ([RoomID], [HotelID], [RoomNumber], [RoomType], [Capacity], [Price]) VALUES (5, 5, N'501', N'Ocean View', 4, CAST(250.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Routes] ON 

INSERT [dbo].[Routes] ([RouteID], [DepartureCity], [ArrivalCity], [DistanceInKm]) VALUES (1, N'Los Angeles', N'New York City', CAST(3900.75 AS Decimal(10, 2)))
INSERT [dbo].[Routes] ([RouteID], [DepartureCity], [ArrivalCity], [DistanceInKm]) VALUES (2, N'London', N'Manchester', CAST(330.50 AS Decimal(10, 2)))
INSERT [dbo].[Routes] ([RouteID], [DepartureCity], [ArrivalCity], [DistanceInKm]) VALUES (3, N'Toronto', N'Brisbane', CAST(15910.20 AS Decimal(10, 2)))
INSERT [dbo].[Routes] ([RouteID], [DepartureCity], [ArrivalCity], [DistanceInKm]) VALUES (4, N'New York City', N'Toronto', CAST(784.30 AS Decimal(10, 2)))
INSERT [dbo].[Routes] ([RouteID], [DepartureCity], [ArrivalCity], [DistanceInKm]) VALUES (5, N'Brisbane', N'Sydney', CAST(769.80 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Routes] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [ServiceName], [Description], [Price]) VALUES (1, N'Wi-Fi', N'High-speed internet access', CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [Description], [Price]) VALUES (2, N'Breakfast', N'Continental breakfast', CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [Description], [Price]) VALUES (3, N'Parking', N'On-site parking', CAST(20.00 AS Decimal(10, 2)))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [Description], [Price]) VALUES (4, N'Gym Access', N'Fitness center access', CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [Description], [Price]) VALUES (5, N'Airport Shuttle', N'Transportation to/from airport', CAST(30.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (1, N'California', 1)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (2, N'New York', 1)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (3, N'London', 2)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (4, N'Ontario', 3)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (5, N'Queensland', 4)
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([TableID], [RestaurantID], [TableNumber], [Capacity]) VALUES (1, 1, 1, 4)
INSERT [dbo].[Tables] ([TableID], [RestaurantID], [TableNumber], [Capacity]) VALUES (2, 1, 2, 6)
INSERT [dbo].[Tables] ([TableID], [RestaurantID], [TableNumber], [Capacity]) VALUES (3, 1, 3, 2)
INSERT [dbo].[Tables] ([TableID], [RestaurantID], [TableNumber], [Capacity]) VALUES (4, 4, 4, 8)
INSERT [dbo].[Tables] ([TableID], [RestaurantID], [TableNumber], [Capacity]) VALUES (5, 5, 5, 4)
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
SET IDENTITY_INSERT [dbo].[TransportCompanies] ON 

INSERT [dbo].[TransportCompanies] ([CompanyID], [CompanyName], [RegistrationNumber]) VALUES (1, N'XYZ Transport', N'XYZ123')
INSERT [dbo].[TransportCompanies] ([CompanyID], [CompanyName], [RegistrationNumber]) VALUES (2, N'ABC Logistics', N'ABC456')
INSERT [dbo].[TransportCompanies] ([CompanyID], [CompanyName], [RegistrationNumber]) VALUES (3, N'LMN Express', N'LMN789')
INSERT [dbo].[TransportCompanies] ([CompanyID], [CompanyName], [RegistrationNumber]) VALUES (4, N'PQR Shipping', N'PQR101')
INSERT [dbo].[TransportCompanies] ([CompanyID], [CompanyName], [RegistrationNumber]) VALUES (5, N'DEF Freight', N'DEF202')
SET IDENTITY_INSERT [dbo].[TransportCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([TripID], [VehicleID], [RouteID], [DepartureDateTime], [ArrivalDateTime]) VALUES (1, 1, 1, CAST(N'2024-01-25T09:00:00.000' AS DateTime), CAST(N'2024-01-26T17:00:00.000' AS DateTime))
INSERT [dbo].[Trips] ([TripID], [VehicleID], [RouteID], [DepartureDateTime], [ArrivalDateTime]) VALUES (2, 2, 2, CAST(N'2024-01-26T12:30:00.000' AS DateTime), CAST(N'2024-01-26T15:00:00.000' AS DateTime))
INSERT [dbo].[Trips] ([TripID], [VehicleID], [RouteID], [DepartureDateTime], [ArrivalDateTime]) VALUES (3, 3, 3, CAST(N'2024-01-27T18:45:00.000' AS DateTime), CAST(N'2024-01-28T08:30:00.000' AS DateTime))
INSERT [dbo].[Trips] ([TripID], [VehicleID], [RouteID], [DepartureDateTime], [ArrivalDateTime]) VALUES (4, 4, 4, CAST(N'2024-01-29T14:00:00.000' AS DateTime), CAST(N'2024-01-29T18:45:00.000' AS DateTime))
INSERT [dbo].[Trips] ([TripID], [VehicleID], [RouteID], [DepartureDateTime], [ArrivalDateTime]) VALUES (5, 5, 5, CAST(N'2024-01-30T11:15:00.000' AS DateTime), CAST(N'2024-01-30T16:30:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Trips] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1, N'user1', N'userpass1', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (2, N'user2', N'password123', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (3, N'user3', N'securepwd', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (4, N'user4', N'userpass123', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (5, N'user5', N'password', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (6, N'Saif', N'saif123', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1006, N'a', N'a', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1007, N'aa', N'$2a$10$5Zo0LBk0cDslEStfUNXFh..jBX5F0a9HUIb2vmr2lJrzcg.xuOmVO', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1008, N'aaa', N'$2a$10$styQ6TSaoTNsOjVOmaeWN.DZoDYuvP7ImP9W9E.8WiMm42MTiX2x.', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1009, N'Example@g.c', N'$2a$10$Sltng9/0GHEWxAcQAOiNM.9HQAXCsmNr5P5Jdh6zwEM84JFMzQTWG', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1010, N'a@gmail.com', N'$2a$10$wmPeJ6J0VfG6NuLX3zT7segTk5DBOlN0vCw4uAua3i7I9iOcF5WNK', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([VehicleID], [CompanyID], [VehicleType], [RegistrationPlate], [Capacity]) VALUES (1, 1, N'Truck', N'XYZ-001', 5000)
INSERT [dbo].[Vehicles] ([VehicleID], [CompanyID], [VehicleType], [RegistrationPlate], [Capacity]) VALUES (2, 2, N'Van', N'ABC-002', 2000)
INSERT [dbo].[Vehicles] ([VehicleID], [CompanyID], [VehicleType], [RegistrationPlate], [Capacity]) VALUES (3, 3, N'Trailer', N'LMN-003', 10000)
INSERT [dbo].[Vehicles] ([VehicleID], [CompanyID], [VehicleType], [RegistrationPlate], [Capacity]) VALUES (4, 4, N'Cargo Plane', N'PQR-004', 20000)
INSERT [dbo].[Vehicles] ([VehicleID], [CompanyID], [VehicleType], [RegistrationPlate], [Capacity]) VALUES (5, 5, N'Ship', N'DEF-005', 30000)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__8A2B6160DB093D3A]    Script Date: 2/19/2024 7:02:03 AM ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hotels] ADD  DEFAULT (NULL) FOR [HotelImg]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([AirlineID])
REFERENCES [dbo].[Airlines] ([AirlineID])
GO
ALTER TABLE [dbo].[PackageActivities]  WITH CHECK ADD FOREIGN KEY([ActivityID])
REFERENCES [dbo].[ResortActivities] ([ActivityID])
GO
ALTER TABLE [dbo].[PackageActivities]  WITH CHECK ADD FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([PackageID])
GO
ALTER TABLE [dbo].[PackageItems]  WITH CHECK ADD FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([PackageID])
GO
ALTER TABLE [dbo].[PackageMeals]  WITH CHECK ADD FOREIGN KEY([MenuItemID])
REFERENCES [dbo].[RestaurantMenuItems] ([MenuItemID])
GO
ALTER TABLE [dbo].[PackageMeals]  WITH CHECK ADD FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([PackageID])
GO
ALTER TABLE [dbo].[PackageServices]  WITH CHECK ADD FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([PackageID])
GO
ALTER TABLE [dbo].[PackageServices]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([GuestID])
REFERENCES [dbo].[Guests] ([GuestID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([RoomID])
GO
ALTER TABLE [dbo].[ReservationServices]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservations] ([ReservationID])
GO
ALTER TABLE [dbo].[ReservationServices]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[ResortReservationActivities]  WITH CHECK ADD FOREIGN KEY([ActivityID])
REFERENCES [dbo].[ResortActivities] ([ActivityID])
GO
ALTER TABLE [dbo].[ResortReservationActivities]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[ResortReservations] ([ReservationID])
GO
ALTER TABLE [dbo].[ResortReservations]  WITH CHECK ADD FOREIGN KEY([GuestID])
REFERENCES [dbo].[ResortGuests] ([GuestID])
GO
ALTER TABLE [dbo].[ResortReservations]  WITH CHECK ADD FOREIGN KEY([ResortID])
REFERENCES [dbo].[Resorts] ([ResortID])
GO
ALTER TABLE [dbo].[ResortReservations]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[ResortRooms] ([RoomID])
GO
ALTER TABLE [dbo].[ResortRooms]  WITH CHECK ADD FOREIGN KEY([ResortID])
REFERENCES [dbo].[Resorts] ([ResortID])
GO
ALTER TABLE [dbo].[RestaurantMenuItems]  WITH CHECK ADD FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([RestaurantID])
GO
ALTER TABLE [dbo].[RestaurantOrderItems]  WITH CHECK ADD FOREIGN KEY([MenuItemID])
REFERENCES [dbo].[RestaurantMenuItems] ([MenuItemID])
GO
ALTER TABLE [dbo].[RestaurantOrderItems]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[RestaurantReservations] ([ReservationID])
GO
ALTER TABLE [dbo].[RestaurantPayments]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[RestaurantReservations] ([ReservationID])
GO
ALTER TABLE [dbo].[RestaurantReservations]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[RestaurantCustomers] ([CustomerID])
GO
ALTER TABLE [dbo].[RestaurantReservations]  WITH CHECK ADD FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([RestaurantID])
GO
ALTER TABLE [dbo].[RestaurantReservations]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[Tables] ([TableID])
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelID])
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([RestaurantID])
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD FOREIGN KEY([RouteID])
REFERENCES [dbo].[Routes] ([RouteID])
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[TransportCompanies] ([CompanyID])
GO
