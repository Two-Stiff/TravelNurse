CREATE OR REPLACE FUNCTION insert_job_specialties()
    RETURNS void AS $$
DECLARE
i INT := 1;
    job_id INT;
    subspecialty_id INT;
BEGIN
    WHILE i <= 30 LOOP
            -- Set values based on even or odd
            IF i % 2 = 0 THEN
                job_id := 1;
                subspecialty_id := 1;
ELSE
                job_id := 2;
                subspecialty_id := 2;
END IF;

            -- Perform the insert
INSERT INTO "JobSubSpecialties" ("JobId", "SubSpecialtyId", "IsRequired")
VALUES (job_id, subspecialty_id, false);

i := i + 1;
END LOOP;
END;
$$ LANGUAGE plpgsql;
