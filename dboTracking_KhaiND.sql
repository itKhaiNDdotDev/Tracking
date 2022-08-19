CREATE TABLE AssignRoute(
    Id             INT            NOT NULL PRIMARY KEY,
    UnitId         INT            NOT NULL,
    CarId          INT            NOT NULL,
    DriverId       INT            NOT NULL,
    TreasurerId    INT            NOT NULL,
    AtmTechnicanId INT            NULL,
    Guard          TEXT NULL,
    BeginTime      TIME        NOT NULL,
    EndTime        TIME        NOT NULL,
    BeginDate      DATETIME   NOT NULL,
    EndDate        DATETIME   NOT NULL,
    Mon            BIT            NOT NULL,
    Tue            BIT            NOT NULL,
    Wed            BIT            NOT NULL,
    Thu            BIT            NOT NULL,
    Fri            BIT            NOT NULL,
    Sat            BIT            NOT NULL,
    Sun            BIT            NOT NULL,
    IssueComand    BIT            NOT NULL,
    RouteId        INT            NOT NULL,
    sendSMS        BIT            NOT NULL
);

CREATE TABLE AtmTechnican(
    Id           INT            NOT NULL PRIMARY KEY,
    Image        TEXT NULL,
    EmployeeCode TEXT NULL,
    Name         TEXT NULL,
    Gender       TEXT NULL,
    PhoneNumber  TEXT NULL,
    Email        TEXT NULL,
    RfidId       INT            NULL,
    UnitId       INT            NOT NULL,
    OffJob       BIT            NOT NULL
);

CREATE TABLE Car(
    Id                INT            NOT NULL PRIMARY KEY,
    LicensePlate      TEXT NULL,
    Type              TEXT NULL,
    DeviceId          INT            NOT NULL,
    UnitId            INT            NOT NULL,
    DriverId          INT            NOT NULL,
    NumberCamera      INT            NOT NULL,
    FirstCam          TEXT NULL,
    FirstCamRotation  INT            NOT NULL,
    SecondCamRotation INT            NOT NULL,
    FuelType          TEXT NULL,
    Fuel              REAL           NULL,
    Uom               TEXT NULL,
    LimitedSpeed      INT            NOT NULL
);

CREATE TABLE Device(
    Id            INT            NOT NULL PRIMARY KEY,
    DeviceCode    TEXT NULL,
    PhoneNumber   TEXT NULL,
    MobileCarrier TEXT NULL,
    ActiveDate    DATETIME   NULL,
    UnitId        INT            NOT NULL,
    Imei          TEXT NULL,
    IsActive      BIT            NOT NULL,
    AllowUpdate   BIT            NOT NULL
);

CREATE TABLE Driver(
    Id           INT            NOT NULL PRIMARY KEY,
    Image        TEXT NULL,
    EmployeeCode TEXT NULL,
    Name         TEXT NULL,
    Gender       TEXT NULL,
    PhoneNumber  TEXT NULL,
    Email        TEXT NULL,
    RfidId       INT            NULL,
    UnitId       INT            NOT NULL,
    OffJob       BIT            NOT NULL
);

CREATE TABLE ManageUnit(
    Id   INT            NOT NULL PRIMARY KEY,
    Name TEXT NULL
);

CREATE TABLE Rfid(
    Id          INT            NOT NULL PRIMARY KEY,
    CardNumber  TEXT NULL,
    Description TEXT NULL,
    Type        TEXT NULL,
    ActiveDate  DATETIME   NULL,
    UnitId      INT            NOT NULL,
    Status      BIT            NOT NULL
);

CREATE TABLE Role(
    Id               INT            NOT NULL PRIMARY KEY,
    Name             TEXT NULL,
    NormalizedName   TEXT NULL,
    ConcurrencyStamp TEXT NULL
);

CREATE TABLE RoleClaims(
    Id         INT            NOT NULL PRIMARY KEY,
    RoleId     INT            NOT NULL,
    ClaimType  TEXT NULL,
    ClaimValue TEXT NULL
);

CREATE TABLE SampleRoutes(
    Id               INT            NOT NULL PRIMARY KEY,
    RouteCode        TEXT NULL,
    UnitId           INT            NOT NULL,
    RouteType        INT            NOT NULL,
    BeginTime        TIME        NOT NULL,
    OverTimeAllowed  INT            NOT NULL,
    ToleranceAllowed INT            NOT NULL,
    Distance         INT            NOT NULL,
    ArrivalTime      INT            NOT NULL
);

CREATE TABLE TransactionPoint(
    Id          INT            NOT NULL PRIMARY KEY,
    PointCode   TEXT NULL,
    PointName   TEXT NULL,
    PointType   INT            NOT NULL,
    UnitId      INT            NOT NULL,
    Address     TEXT NULL,
    Longtitude  REAL           NOT NULL,
    Latitude    REAL           NOT NULL,
    Contact     TEXT NULL,
    PhoneNumber TEXT NULL,
    Fax         TEXT NULL,
    Branch      TEXT NULL
);

CREATE TABLE Treasurer(
    Id           INT            NOT NULL PRIMARY KEY,
    Image        TEXT NULL,
    EmployeeCode TEXT NULL,
    Name         TEXT NULL,
    Gender       TEXT NULL,
    PhoneNumber  TEXT NULL,
    Email        TEXT NULL,
    RfidId       INT            NULL,
    Unit         TEXT NULL,
    OffJob       BIT            NOT NULL
);

CREATE TABLE WarrningStaff(
    Id           INT            NOT NULL PRIMARY KEY,
    Image        TEXT NULL,
    EmployeeCode TEXT NULL,
    Name         TEXT NULL,
    Gender       TEXT NULL,
    PhoneNumber  TEXT NULL,
    Email        TEXT NULL,
    RfidId       INT            NULL,
    UnitId       INT            NOT NULL,
    OffJob       BIT            NOT NULL
);

CREATE TABLE WarningLog(
    Id            INT            NOT NULL PRIMARY KEY,
    AssignRouteId INT            NOT NULL,
    Type          INT            NOT NULL,
    Message       TEXT NULL,
    SendTime      DATETIME   NOT NULL
);

CREATE TABLE ImageLog(
    Id            INT            NOT NULL PRIMARY KEY,
    AssignRouteId INT            NOT NULL,
    Image         BINARY(255) NULL,
    SendTime      DATETIME   NOT NULL
);

CREATE TABLE UserTokens(
    UserId        INT            NOT NULL PRIMARY KEY,
    LoginProvider TEXT NULL,
    Name          TEXT NULL,
    Value         TEXT NULL
);

CREATE TABLE UserRoles(
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    PRIMARY KEY (UserId, RoleId)
);

CREATE TABLE UserLogins(
    UserId              INT            NOT NULL PRIMARY KEY,
    LoginProvider       TEXT NULL,
    ProviderKey         TEXT NULL,
    ProviderDisplayName TEXT NULL
);

CREATE TABLE UserClaims(
    Id         INT            NOT NULL PRIMARY KEY,
    UserId     INT            NOT NULL,
    ClaimType  TEXT NULL,
    ClaimValue TEXT NULL
);

CREATE TABLE User(
    Id                   INT                NOT NULL PRIMARY KEY,
    UserName             TEXT     NULL,
    NormalizedUserName   TEXT     NULL,
    Email                TEXT     NULL,
    NormalizedEmail      TEXT     NULL,
    EmailConfirmed       BIT                NOT NULL,
    PasswordHash         TEXT     NULL,
    SecurityStamp        TEXT     NULL,
    ConcurrencyStamp     TEXT     NULL,
    PhoneNumber          TEXT     NULL,
    PhoneNumberConfirmed BIT                NOT NULL,
    TwoFactorEnabled     BIT                NOT NULL,
    LockoutEnd           TIMESTAMP  NULL,
    LockoutEnabled       BIT                NOT NULL,
    AccessFailedCount    INT                NOT NULL,
    fullname             TEXT     NULL,
    is_active            BIT                NOT NULL,
    is_admin             BIT                NOT NULL,
    create_date          DATETIME       NOT NULL,
);


CREATE TABLE TracePointForRoute(
    Id              INT NOT NULL PRIMARY KEY,
    StopPointId     INT NULL,
    TravelTimeByMin INT NOT NULL,
    SampleRouteId   INT NULL
);


