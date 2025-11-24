#!/usr/bin/env bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
	CREATE USER docker WITH ENCRYPTED PASSWORD 'test9876';
	CREATE DATABASE docker OWNER docker;
EOSQL

psql -v ON_ERROR_STOP=1 --username "docker" --dbname "docker" <<-EOSQL
  CREATE TABLE film (
    id SERIAL PRIMARY KEY,
    titre TEXT NOT NULL,
    titreCA TEXT NOT NULL,
    Annee Date NOT NULL
  );

  INSERT INTO film (titre, titreCA, annee) VALUES
  ('The Lord of the Rings: The Fellowship of the Ring', 'Le Seigneur des anneaux : La Communauté de l''anneau', '2001-01-01'),
  ('The Lord of the Rings: The Two Towers',               'Le Seigneur des anneaux : Les Deux Tours',          '2002-01-01'),
  ('The Lord of the Rings: The Return of the King',       'Le Seigneur des anneaux : Le Retour du roi',        '2003-01-01'),
  ('The Dark Knight',                                     'Le Chevalier noir',                                 '2008-01-01'),
  ('Inception',                                           'Inception',                                         '2010-01-01'),
  ('The Matrix',                                          'La Matrice',                                        '1999-01-01'),
  ('Pulp Fiction',                                        'Pulp Fiction',                                      '1994-01-01'),
  ('Fight Club',                                          'Fight Club',                                        '1999-01-01'),
  ('Interstellar',                                        'Interstellaire',                                    '2014-01-01'),
  ('The Lion King',                                       'Le roi lion',                                       '1994-01-01'),
  ('Toy Story',                                           'Histoire de jouets',                                '1995-01-01'),
  ('Finding Nemo',                                        'Le Monde de Nemo',                                  '2003-01-01'),
  ('Up',                                                  'Là-haut',                                           '2009-01-01'),
  ('Inside Out',                                          'Vice-versa',                                        '2015-01-01'),
  ('Frozen',                                              'La Reine des neiges',                               '2013-01-01'),
  ('Titanic',                                             'Titanic',                                           '1997-01-01'),
  ('Jurassic Park',                                       'Jurassic Park',                                     '1993-01-01'),
  ('Avatar',                                              'Avatar',                                            '2009-01-01'),
  ('Spider-Man: No Way Home',                             'Spider-Man : Sans retour',                          '2021-01-01'),
  ('Mad Max: Fury Road',                                  'Mad Max : La route du chaos',                       '2015-01-01');
EOSQL