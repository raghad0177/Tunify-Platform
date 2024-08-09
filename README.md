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

## Repository Design Pattern

### Overview
The Repository Design Pattern is a structural pattern that helps to separate the data access logic from the business logic in an application. By using repositories, the data access code is encapsulated within a set of classes that are responsible for handling operations related to a specific entity or set of entities. This approach makes the application more modular, testable, and maintainable.

### Benefits of the Repository Pattern

1. **Separation of Concerns**: By encapsulating the data access logic within repository classes, the business logic is separated from the data access layer. This separation makes the application easier to manage and understand.

2. **Testability**: The use of interfaces in the Repository Pattern allows for easy mocking of the data access layer during unit testing. This means you can test the business logic without needing to interact with the actual database.

3. **Modularity**: Repositories provide a modular structure for the data access code. Each repository class is responsible for a specific entity, which makes it easier to manage and update the data access logic for that entity.

4. **Code Reusability**: By creating generic methods in the repository, you can reuse the same methods for multiple entities. This reduces code duplication and makes the codebase more maintainable.

5. **Centralized Data Access Logic**: All data access code is centralized in the repository classes, making it easier to implement changes in the data access layer without affecting the rest of the application.

### Implementation in Tunify Platform
In this lab, the Repository Design Pattern was integrated into the Tunify Platform to manage data access for entities such as `Users`, `Playlist`, `Song`, and `Artist`. Each entity has a corresponding repository interface and implementation class that encapsulates the data access logic.

- **Repository Interfaces**: These interfaces define the contract for data access operations, including CRUD operations and any entity-specific methods.

- **Repository Implementations**: The implementation classes provide the actual data access logic, interacting with the `DbContext` to perform operations on the database.

- **Controller Refactoring**: Controllers were refactored to use repositories instead of interacting directly with the `DbContext`. This refactoring improves the modularity and testability of the application.

By adopting the Repository Pattern, the Tunify Platform has become more modular, easier to test, and more maintainable, with a clear separation between business logic and data access logic.
