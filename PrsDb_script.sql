use PrsDbc37;
go
INSERT Users (Username, Password, Firstname, Lastname, IsReviewer, IsAdmin)
    VALUES ('sa', 'sa', 'System', 'Admin', 1, 1),
           ('rv', 'rv', 'System', 'Reviewer', 1, 0),
           ('us', 'us', 'System', 'User', 0, 0);
GO
INSERT Vendors (Code, Name, Address, City, State, Zip)
    VALUES     ('AMAZ', 'Amazon', '1 Amazon Way', 'Seattle', 'WA', '98765'),
               ('TARG', 'Target', '1 Target Dr', 'Minneapolis', 'MN', '76543');
GO
INSERT Products (PartNbr, Name, Price, Unit, VendorId)
    VALUES      ('ECHO', 'Echo', 100, 'Each', (SELECT Id from Vendors where Code = 'AMAZ')),
                ('ECHODOT', 'Echo Dot', 40, 'Each', (SELECT Id from Vendors where Code = 'AMAZ')),
                ('PAPER', 'Paper', 5, 'Ream', (SELECT Id from Vendors where Code = 'AMAZ'));
Go