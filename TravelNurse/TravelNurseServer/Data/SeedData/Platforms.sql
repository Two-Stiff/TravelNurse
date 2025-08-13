CREATE OR REPLACE FUNCTION insert_random_platforms()
    RETURNS void AS $$
DECLARE
i INT := 1;
    platform_names TEXT[] := ARRAY[
        'Indeed',
        'LinkedIn',
        'Glassdoor',
        'Monster',
        'ZipRecruiter',
        'CareerBuilder',
        'SimplyHired',
        'Upwork',
        'Freelancer',
        'Toptal',
        'PeoplePerHour',
        'Dribbble',
        'Stack Overflow',
        'Remote OK',
        'We Work Remotely',
        'AngelList',
        'Guru',
        'FlexJobs',
        'Outsourcely',
        'Workana',
        'Hubstaff Talent',
        'Jobspresso',
        'Truelancer',
        'Fiverr',
        'Behance',
        'Dice',
        'Jobvite',
        'Snagajob',
        'Workable',
        'Hired'
        ];
BEGIN
    WHILE i <= 30 LOOP
            INSERT INTO "Platforms" ("Name")
            VALUES (platform_names[i]);
            i := i + 1;
END LOOP;
END;
$$ LANGUAGE plpgsql;

SELECT insert_random_platforms();
