DO $$
DECLARE
i INT := 0;
    name TEXT;
    street TEXT;
    city TEXT;
    zip TEXT;
    latitude DECIMAL(18,2);
    longitude DECIMAL(18,2);
    phone TEXT;
    mailing_address TEXT;
    mailing_city TEXT;
    mailing_zip TEXT;
    fax TEXT;
    billing_name TEXT;
    website TEXT;
    bed_size INT;
    auto_offer BOOLEAN;
    accepts_travelers BOOLEAN;
    supplemental_nursing_override BOOLEAN;
    is_advanced_practice BOOLEAN;
    permanent_note TEXT;
    payroll_billing_note TEXT;
    last_work_order_date TIMESTAMP;
    last_note_date TIMESTAMP;
    state_id INT;
    mailing_state_id INT;
    do_not_rehire_reason TEXT;

    -- Sample arrays for random selection
names TEXT[] := ARRAY[
        'Central Hospital', 'Maplewood Clinic', 'Sunrise Medical Center',
        'Grandview Health', 'Lakeside Facility', 'Riverside Care', 'Pinehill Medical',
        'Cedar Valley Clinic', 'Mountainview Hospital', 'Silverlake Health'
    ];
    street_names TEXT[] := ARRAY[
        'Main St', 'Elm St', 'Maple Ave', 'Oak St', 'Pine St',
        'Cedar Ln', 'Walnut St', 'Chestnut Blvd', 'Birch Rd', 'Spruce Dr'
    ];
    cities TEXT[] := ARRAY[
        'Springfield', 'Rivertown', 'Lakeview', 'Hilltop', 'Brookside',
        'Fairview', 'Greenville', 'Kingston', 'Madison', 'Oakdale'
    ];
    zip_codes TEXT[] := ARRAY[
        '12345', '23456', '34567', '45678', '56789',
        '67890', '78901', '89012', '90123', '01234'
    ];
    phone_prefixes TEXT[] := ARRAY['555', '444', '333', '222', '111'];
    billing_names TEXT[] := ARRAY[
        'Acme Billing', 'NorthStar Finance', 'HealthPay Corp',
        'MedBill Services', 'CareCredit', 'Prime Billing'
    ];
    websites TEXT[] := ARRAY[
        'http://www.centralhospital.com', 'http://www.maplewoodclinic.org',
        'http://www.sunrisemedical.net', 'http://www.grandviewhealth.com',
        'http://www.lakesidefacility.org'
    ];
    notes TEXT[] := ARRAY[
        'No issues.', 'Requires follow-up.', 'Pending review.',
        'Priority client.', 'Confidential notes here.', 'Special billing instructions.'
    ];
    reasons TEXT[] := ARRAY[
        'Policy violation', 'Performance issues', 'Voluntary resignation',
        'Contract ended', 'No longer eligible'
    ];
    states_ids INT[] := ARRAY[1,2,3,4,5];  -- Example State IDs — change to match your States table

BEGIN
    WHILE i < 30 LOOP
        name := names[LEAST(FLOOR(random() * array_length(names, 1)) + 1, array_length(names,1))];
        street := (100 + FLOOR(random() * 900))::TEXT || ' ' ||
                  street_names[LEAST(FLOOR(random() * array_length(street_names, 1)) + 1, array_length(street_names,1))];
        city := cities[LEAST(FLOOR(random() * array_length(cities,1)) + 1, array_length(cities,1))];
        zip := zip_codes[LEAST(FLOOR(random() * array_length(zip_codes,1)) + 1, array_length(zip_codes,1))];
        latitude := ROUND((random() * 180 - 90)::NUMERIC, 2);
        longitude := ROUND((random() * 360 - 180)::NUMERIC, 2);
        phone := phone_prefixes[LEAST(FLOOR(random() * array_length(phone_prefixes,1)) + 1, array_length(phone_prefixes,1))] || '-' ||
                 (100 + FLOOR(random() * 900))::TEXT || '-' || (1000 + FLOOR(random() * 9000))::TEXT;
        mailing_address := (100 + FLOOR(random() * 900))::TEXT || ' ' ||
                           street_names[LEAST(FLOOR(random() * array_length(street_names, 1)) + 1, array_length(street_names,1))];
        mailing_city := cities[LEAST(FLOOR(random() * array_length(cities,1)) + 1, array_length(cities,1))];
        mailing_zip := zip_codes[LEAST(FLOOR(random() * array_length(zip_codes,1)) + 1, array_length(zip_codes,1))];
        fax := phone_prefixes[LEAST(FLOOR(random() * array_length(phone_prefixes,1)) + 1, array_length(phone_prefixes,1))] || '-' ||
               (100 + FLOOR(random() * 900))::TEXT || '-' || (1000 + FLOOR(random() * 9000))::TEXT;
        billing_name := billing_names[LEAST(FLOOR(random() * array_length(billing_names,1)) + 1, array_length(billing_names,1))];
        website := websites[LEAST(FLOOR(random() * array_length(websites,1)) + 1, array_length(websites,1))];
        bed_size := FLOOR(random() * 500 + 50)::INT;
        auto_offer := (random() < 0.5);
        accepts_travelers := (random() < 0.5);
        supplemental_nursing_override := (random() < 0.5);
        is_advanced_practice := (random() < 0.5);
        permanent_note := notes[LEAST(FLOOR(random() * array_length(notes,1)) + 1, array_length(notes,1))];
        payroll_billing_note := notes[LEAST(FLOOR(random() * array_length(notes,1)) + 1, array_length(notes,1))];
        last_work_order_date := NOW() - (FLOOR(random() * 365)) * INTERVAL '1 day';
        last_note_date := NOW() - (FLOOR(random() * 365)) * INTERVAL '1 day';
        state_id := states_ids[LEAST(FLOOR(random() * array_length(states_ids,1)) + 1, array_length(states_ids,1))];
        mailing_state_id := states_ids[LEAST(FLOOR(random() * array_length(states_ids,1)) + 1, array_length(states_ids,1))];
        do_not_rehire_reason := reasons[LEAST(FLOOR(random() * array_length(reasons,1)) + 1, array_length(reasons,1))];

INSERT INTO "Facilities"(
    "Name", "StreetAddress", "City", "ZipCode", "Latitude", "Longitude",
    "PhoneNumber", "MailingAddress", "MailingCity", "MailingZipCode", "Fax",
    "BillingName", "WebsiteLink", "BedSize", "AutoOffer", "AcceptsTravelers",
    "SupplementalNursingOverride", "IsAdvancedPractice", "PermanentNote",
    "PayrollBillingNote", "LastWorkOrderDate", "LastNoteDate", "StateId",
    "MailingStateId", "DoNotRehireReason"
)
VALUES (
           name, street, city, zip, latitude, longitude,
           phone, mailing_address, mailing_city, mailing_zip, fax,
           billing_name, website, bed_size, auto_offer, accepts_travelers,
           supplemental_nursing_override, is_advanced_practice, permanent_note,
           payroll_billing_note, last_work_order_date, last_note_date, state_id,
           mailing_state_id, do_not_rehire_reason
       );

i := i + 1;
END LOOP;
END $$;
