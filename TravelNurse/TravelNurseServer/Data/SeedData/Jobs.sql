CREATE OR REPLACE FUNCTION insert_random_jobs()
    RETURNS void AS $$
DECLARE
i INT := 1;
    dt_now TIMESTAMP := NOW();
    job_titles TEXT[] := ARRAY[
        'Registered Nurse',
        'Physical Therapist',
        'Medical Assistant',
        'Pharmacist',
        'Occupational Therapist',
        'Radiologic Technologist',
        'Speech-Language Pathologist',
        'Respiratory Therapist',
        'Surgical Technician',
        'Clinical Psychologist'
        ];
    notes_samples TEXT[] := ARRAY[
        'Experienced in acute care settings.',
        'Skilled with patient documentation.',
        'Certified in CPR and first aid.',
        'Strong communication skills.',
        'Familiar with electronic medical records.',
        'Bilingual in English and Spanish.',
        'Proven ability to work under pressure.',
        'Excellent teamwork and collaboration.',
        'Flexible schedule and reliable.',
        'Background in pediatric care.'
        ];
    requirements_samples TEXT[] := ARRAY[
        'Must have valid RN license.',
        'Ability to lift 50 lbs frequently.',
        'Willingness to work night shifts.',
        'Excellent organizational skills.',
        'Must pass background check.',
        'Experience with EMR systems required.',
        'Strong customer service orientation.',
        'Valid driver’s license required.',
        'Ability to work in a fast-paced environment.',
        'CPR certification preferred.'
        ];
BEGIN
    WHILE i <= 30 LOOP
            INSERT INTO "Jobs" (
                "JobTitle",
                "UniqueNotes",
                "PlatformId",
                "HousingProvided",
                "HideExternally",
                "ContractLengthWeeks",
                "StartDate",
                "ExpiresOn",
                "RepostedOn",
                "FacilityId",
                "DisciplineId",
                "SpecialtyId",
                "JobStrength",
                "HideCity",
                "AutoPosted",
                "AllowsAutoposterUpdate",
                "Requirements",
                "JobType"
            ) VALUES (
                         job_titles[(i - 1) % array_length(job_titles,1) + 1],
                         notes_samples[(i - 1) % array_length(notes_samples,1) + 1],
                         FLOOR(RANDOM() * 25 + 1)::int,
                         (random() < 0.5),
                         (random() < 0.5),
                         FLOOR(random() * 52 + 1)::int,
                         dt_now - (random() * INTERVAL '30 days'),
                         dt_now + (60 + FLOOR(random() * 60)) * INTERVAL '1 day',
                         dt_now - (random() * INTERVAL '15 days'),
                         1 + FLOOR(random())::int, --facility id
                         1 + FLOOR(random() * 10)::int,
                         1 + FLOOR(random() * 10)::int,
                         round((random() * 10.0)::numeric, 2),
                         (random() < 0.5),
                         (random() < 0.5),
                         (random() < 0.5),
                         requirements_samples[(i - 1) % array_length(requirements_samples,1) + 1],
                         FLOOR(RANDOM() * 3 + 1)::int
                     );
            i := i + 1;
END LOOP;
END;
$$ LANGUAGE plpgsql;


SELECT insert_random_jobs();