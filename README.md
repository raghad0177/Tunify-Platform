# Tunify Platform

## Overview
Tunify Platform is a web application designed to manage music-related entities, such as users, subscriptions, playlists, songs, artists, and albums. The platform integrates with a SQL Server database to store and manage data, reflecting the relationships between these entities.

## The Tunify ERD Diagram
![Tunify](https://github.com/user-attachments/assets/e68fdd72-7642-43f3-b92a-0bfe9a1cd843)

### Entity Relationships
- **User**: Can have multiple subscriptions and create multiple playlists.
- **Subscription**: Belongs to a user and can include various subscription plans.
- **Playlist**: Created by a user, contains multiple songs, and can be shared.
- **Song**: Can belong to multiple playlists and albums, and is associated with an artist.
- **Artist**: Can produce multiple albums and songs.
- **Album**: Contains multiple songs and is associated with an artist.
- **PlaylistSongs**: A join table that establishes a many-to-many relationship between playlists and songs, enabling a song to be in multiple playlists and a playlist to contain multiple songs.

