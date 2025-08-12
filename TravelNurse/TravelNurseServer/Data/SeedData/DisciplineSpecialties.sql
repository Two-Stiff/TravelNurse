INSERT INTO "DisciplineSpecialties" (
    "DisciplineId",
    "SpecialtyId",
    "CreatedOn",
    "ModifiedOn",
    "DeletedOn"
)
SELECT
    d."Id",
    sp."Id",
    now(),
    now(),
    '1776-07-16'::date
FROM
    "Disciplines" d
        CROSS JOIN "Specialties" sp
WHERE
    d."Name" = 'DIAGNOSTIC IMAGING'
  AND sp."Name" IN ('CATH LAB TECH', 'CT', 'ECHO', 'MAMMOGRAPHY', 'MRI', 'Nuclear Medicine', 'ULTRASOUND TECHNOLOGISTS', 'VASCULAR TECHNOLOGIST',
                    'X-RAY', 'UNCATEGORIZED', 'Electrophysiology', 'Interventional Radiology Tech', 'MANAGER'
    );



INSERT INTO "DisciplineSpecialties" (
    "DisciplineId",
    "SpecialtyId",
    "CreatedOn",
    "ModifiedOn",
    "DeletedOn"
)
SELECT
    d."Id",
    sp."Id",
    now(),
    now(),
    '1776-07-16'::date
FROM
    "Disciplines" d
        CROSS JOIN "Specialties" sp
WHERE
    d."Name" = 'CARDIOPULMONARY'
  AND sp."Name" IN ('Respiratory Therapist', 'UNCATEGORIZED');


INSERT INTO "DisciplineSpecialties" (
    "DisciplineId",
    "SpecialtyId",
    "CreatedOn",
    "ModifiedOn",
    "DeletedOn"
)
SELECT
    d."Id",
    sp."Id",
    now(),
    now(),
    '1776-07-16'::date
FROM
    "Disciplines" d
        CROSS JOIN "Specialties" sp
WHERE
    d."Name" = 'MEDICAL LABORATORY'
  AND sp."Name" IN ('Cyto Tech', 'Histo Tech', 'Med Lab Tech', 'Med Tech', 'PHLEBOTOMIST', 'Pathology Assistant', 'Lab Director', 'VASCULAR TECHNOLOGIST',
                    'Microbiologist', 'Laboratory Assistant'
    );

INSERT INTO "DisciplineSpecialties" (
    "DisciplineId",
    "SpecialtyId",
    "CreatedOn",
    "ModifiedOn",
    "DeletedOn"
)
SELECT
    d."Id",
    sp."Id",
    now(),
    now(),
    '1776-07-16'::date
FROM
    "Disciplines" d
        CROSS JOIN "Specialties" sp
WHERE
    d."Name" = 'RN'
  AND sp."Name" IN ('OR - OPERATING ROOM',
                    'ER - EMERGENCY ROOM',
                    'ICU - INTENSIVE CARE',
                    'M/S - MEDICAL SURGICAL',
                    'PEDS - PEDIATRICS',
                    'PACU/RECOVERY', 'NICU - NEONATAL INTENSIVE CARE', 'PICU - PEDIATRIC INTENSIVE CARE',
                    'L&D - LABOR AND DELIVERY', 'OR TECH'
    , 'PSYCH', 'Radiology', 'POST PARTUM', 'TELEMETRY', 'TCU-TRANSITIONAL CARE', 'PCU-PROGRESSIVE CARE', 'OB', 'DIALYSIS'
    );

