DO $$
    DECLARE
i INT := 1;
        d_id INT;

        first_names TEXT[] := ARRAY['Olivia', 'Liam', 'Emma', 'Noah', 'Ava', 'Elijah', 'Sophia', 'James', 'Isabella', 'Benjamin'];
        last_names  TEXT[] := ARRAY['Smith', 'Johnson', 'Williams', 'Brown', 'Jones', 'Garcia', 'Miller', 'Davis', 'Rodriguez', 'Martinez'];
        maiden_names TEXT[] := ARRAY['Taylor', 'Anderson', 'Thomas', 'Jackson', 'White', 'Harris', 'Martin', 'Thompson', 'Moore', 'Clark'];
        street_names TEXT[] := ARRAY['Maple St', 'Oak Ave', 'Pine Rd', 'Cedar Blvd', 'Elm St', 'Birch Way', 'Spruce Ln', 'Ash Ct', 'Walnut Dr', 'Cherry Pl'];
        cities       TEXT[] := ARRAY['Austin', 'Chicago', 'Denver', 'Seattle', 'Miami', 'Dallas', 'Boston', 'Atlanta', 'Phoenix', 'Nashville'];
        ref_names    TEXT[] := ARRAY['Karen Smith', 'David Lee', 'Sarah Johnson', 'Michael Brown', 'Emily Clark', 'Brian Davis', 'Laura Garcia', 'Kevin Miller', 'Amy Martinez', 'Chris Wilson'];

        fname TEXT;
        lname TEXT;
        maiden TEXT;
        street TEXT;
        city TEXT;
        referral TEXT;
BEGIN
        WHILE i <= 30 LOOP
                fname := first_names[LEAST(FLOOR(random() * array_length(first_names, 1) + 1)::int, array_length(first_names, 1))];
                lname := last_names[LEAST(FLOOR(random() * array_length(last_names, 1) + 1)::int, array_length(last_names, 1))];
                maiden := maiden_names[LEAST(FLOOR(random() * array_length(maiden_names, 1) + 1)::int, array_length(maiden_names, 1))];
                street := (100 + random() * 900)::int || ' ' ||
                          street_names[LEAST((floor(random() * array_length(street_names, 1)) + 1)::int, array_length(street_names, 1))];

                city := cities[LEAST(FLOOR(random() * array_length(cities, 1) + 1)::int, array_length(cities, 1))];
                referral := ref_names[LEAST(FLOOR(random() * array_length(ref_names, 1) + 1)::int, array_length(ref_names, 1))];

SELECT "Id" INTO d_id
FROM "Disciplines"
ORDER BY random()
    LIMIT 1;

INSERT INTO "Providers" (
    "PreferredFirstName",
    "FirstName",
    "LastName",
    "MaidenName",
    "PrimaryPhoneNumber",
    "AlternativePhoneNumber",
    "IsPrimaryPhoneNumberInService",
    "IsAlternativePhoneNumberInService",
    "Email",
    "AlternateEmail",
    "DateOfBirth",
    "Ssn",
    "LastFourSsn",
    "PaycomEeCode",
    "UserId",
    "Username",
    "StreetAddress",
    "City",
    "StateId",
    "ZipCode",
    "TemporaryStreetAddress",
    "TemporaryCity",
    "TemporaryStateId",
    "TemporaryZipCode",
    "AvailabilityDate",
    "ReferredBy",
    "ReferralDate",
    "SensitiveDataModifiedOn",
    "ForceNextLogout",
    "TravelerId",
    "LastRecruiterId",
    "DisciplineId",
    "IsPriority"
)
VALUES (
           fname,
           fname,
           lname,
           maiden,
           '555-123-' || LPAD(i::text, 4, '0'),
           '555-987-' || LPAD(i::text, 4, '0'),
           TRUE,
           FALSE,
           LOWER(fname || '.' || lname || i || '@example.com'),
           LOWER(fname || '.' || lname || i || '@altmail.com'),
           NOW() - (365 * (20 + random()*20)) * INTERVAL '1 day',
           LPAD((100000000 + random()*899999999)::int::text, 9, '0'),
           LPAD((1000 + random()*8999)::int::text, 4, '0'),
           'PCODE' || i,
           gen_random_uuid(),
           LOWER(fname || '_' || lname || '_' || i),
           street,
           city,
           NULL,
           'ZIP' || LPAD(i::text, 5, '0'),
           street || ' Temp',
           city || 'Temp',
           NULL,
           'TZIP' || LPAD(i::text, 5, '0'),
           NOW() + (random() * 30) * INTERVAL '1 day',
           referral,
           NOW() - (random() * 30) * INTERVAL '1 day',
           NOW(),
           FALSE,
           NULL,
           NULL,
           d_id,
           (random() > 0.5)
       );

i := i + 1;
END LOOP;
END $$;
