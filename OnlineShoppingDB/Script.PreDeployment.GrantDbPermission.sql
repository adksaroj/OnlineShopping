﻿USE [OnlineShopping]
GO
CREATE USER [IIS APPPOOL\OnlineShopping] FOR LOGIN [IIS APPPOOL\OnlineShopping] WITH DEFAULT_SCHEMA=[db_owner]
GO
USE [OnlineShopping]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [IIS APPPOOL\OnlineShopping]
GO
USE [OnlineShopping]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\OnlineShopping]
GO
