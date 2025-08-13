Pattern
--------------------------
-- Dto / Service injection
-- Entity framework context

Troubleshoot
--------------------------
-- Postgresql entity framework relation "table" does not exist
    -- Make sure the connection string is correct and the right database is connected

-- Parallel calls at the same time between parent and child using the same context
    -- Use DbContextFactory