using Npgsql;
using System.Threading.Tasks;
using System.Collections.Generic;
using app.Classes;

namespace app.Database
{
    // Klass för att hantera alla queries mot databasen
    public class Queries
    {
        private NpgsqlDataSource _database;

        // Konstruktor för att initialisera databaskopplingen
        public Queries(NpgsqlDataSource database)
        {
            _database = database;
        }

        // Metod för att registrera en ny gäst
        public async Task RegisterGuest(string email, string firstName, string lastName, string phone, DateTime dateOfBirth)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("INSERT INTO guests (email, firstName, lastName, phone, dateOfBirth, regDate, blocked) VALUES ($1, $2, $3, $4, $5, CURRENT_TIMESTAMP, FALSE)"))
                {
                    cmd.Parameters.AddWithValue(email);
                    cmd.Parameters.AddWithValue(firstName);
                    cmd.Parameters.AddWithValue(lastName);
                    cmd.Parameters.AddWithValue(phone);
                    cmd.Parameters.AddWithValue(dateOfBirth);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering guest: {ex.Message}");
            }
        }

        // Metod för att söka efter lediga rum med specificerade sökkriterier
        public async Task<List<Room>> SearchAvailableRooms(DateTime startDate, DateTime endDate)
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating FROM rooms LEFT JOIN bookings ON rooms.id = bookings.room AND bookings.startDate <= $1 AND bookings.endDate >= $2 WHERE bookings.id IS NULL AND rooms.id NOT IN ( SELECT room FROM bookings WHERE startDate <= $3 AND endDate >= $4 )"))
                {
                    cmd.Parameters.AddWithValue(startDate);
                    cmd.Parameters.AddWithValue(endDate);
                    cmd.Parameters.AddWithValue(startDate);
                    cmd.Parameters.AddWithValue(endDate);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching available rooms: {ex.Message}");
            }
            return rooms;
        }

        // Metod för att skapa en ny bokning
        public async Task CreateBooking(int admin, int room, int guest, DateTime startDate, DateTime endDate)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("INSERT INTO bookings (admin, room, guest, startDate, endDate) VALUES ($1, $2, $3, $4, $5)"))
                {
                    cmd.Parameters.AddWithValue(admin);
                    cmd.Parameters.AddWithValue(room);
                    cmd.Parameters.AddWithValue(guest);
                    cmd.Parameters.AddWithValue(startDate);
                    cmd.Parameters.AddWithValue(endDate);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating booking: {ex.Message}");
            }
        }

        // Metod för att erbjuda tilläggstjänster (extrasäng, halvpension, helpension)
        public async Task AddBookingAddon(int booking, int addon, int amount)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("INSERT INTO addOnsXBookings (booking, addon, amount) VALUES ($1, $2, $3)"))
                {
                    cmd.Parameters.AddWithValue(booking);
                    cmd.Parameters.AddWithValue(addon);
                    cmd.Parameters.AddWithValue(amount);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding booking addon: {ex.Message}");
            }
        }

        // Metod för att ändra detaljer i en bokning
        public async Task UpdateBooking(int id, DateTime startDate, DateTime endDate)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("UPDATE bookings SET startDate = $1, endDate = $2 WHERE id = $3"))
                {
                    cmd.Parameters.AddWithValue(startDate);
                    cmd.Parameters.AddWithValue(endDate);
                    cmd.Parameters.AddWithValue(id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating booking: {ex.Message}");
            }
        }

        // Metod för att avboka
        public async Task DeleteBooking(int id)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("DELETE FROM bookings WHERE id = $1"))
                {
                    cmd.Parameters.AddWithValue(id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting booking: {ex.Message}");
            }
        }


        // Metod för att söka på boenden baserat på avstånd till strand
        public async Task<List<Room>> SearchRoomsByDistanceToBeach(int maxDistance)
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating, sightsXRooms.distance FROM rooms JOIN sightsXRooms ON rooms.id = sightsXRooms.room JOIN sights ON sights.id = sightsXRooms.sight WHERE sights.name = 'Beach' AND sightsXRooms.distance <= $1"))
                {
                    cmd.Parameters.AddWithValue(maxDistance);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching rooms by distance to beach: {ex.Message}");
            }
            return rooms;
        }

        // Metod för att söka på boenden baserat på avstånd till centrum
        public async Task<List<Room>> SearchRoomsByDistanceToCityCenter(int maxDistance)
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating, sightsXRooms.distance FROM rooms JOIN sightsXRooms ON rooms.id = sightsXRooms.room JOIN sights ON sights.id = sightsXRooms.sight WHERE sights.name = 'City Center' AND sightsXRooms.distance <= $1"))
                {
                    cmd.Parameters.AddWithValue(maxDistance);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching rooms by distance to city center: {ex.Message}");
            }
            return rooms;
        }

        // Metod för att sortera sökresultat på pris (lågt till högt)
        public async Task<List<Room>> SortRoomsByPrice()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating FROM rooms ORDER BY rooms.priceDay ASC"))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sorting rooms by price: {ex.Message}");
            }
            return rooms;
        }

        // Metod för att sortera sökresultat på omdöme (högt till lågt)
        public async Task<List<Room>> SortRoomsByRating()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating FROM rooms ORDER BY rooms.rating DESC"))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sorting rooms by rating: {ex.Message}");
            }
            return rooms;
        }


        // Metod för att beskriva sällskapet
        public async Task<List<Guest>> DescribeGroup(int bookingId)
        {
            List<Guest> guests = new List<Guest>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT g.id, g.email, g.firstName, g.lastName, g.phone, g.dateOfBirth, g.regDate, g.blocked FROM guests g JOIN groups gr ON g.id = gr.guest WHERE gr.booking = $1"))
                {
                    cmd.Parameters.AddWithValue(bookingId);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            guests.Add(new Guest(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5), reader.GetDateTime(6), reader.GetBoolean(7)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error describing group: {ex.Message}");
            }
            return guests;
        }

        // Metod för att kombinera alla sökkriterier
        public async Task<List<Room>> CombinedSearch(DateTime startDate, DateTime endDate, int maxDistanceToBeach, bool pool, bool eveningEntertainment, bool kidsClub, bool restaurant)
        {
            List<Room> rooms = new List<Room>();
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT rooms.id, rooms.size, rooms.location, rooms.priceDay, rooms.rating FROM rooms LEFT JOIN bookings ON rooms.id = bookings.room AND bookings.startDate <= $1 AND bookings.endDate >= $2 JOIN sightsXRooms ON rooms.id = sightsXRooms.room JOIN sights ON sights.id = sightsXRooms.sight WHERE bookings.id IS NULL AND sights.name = 'Beach' AND sightsXRooms.distance <= $3 AND rooms.pool = $4 AND rooms.eveningEntertainment = $5 AND rooms.kidsClub = $6 AND rooms.restaurant = $7 ORDER BY rooms.priceDay ASC"))
                {
                    cmd.Parameters.AddWithValue(startDate);
                    cmd.Parameters.AddWithValue(endDate);
                    cmd.Parameters.AddWithValue(maxDistanceToBeach);
                    cmd.Parameters.AddWithValue(pool);
                    cmd.Parameters.AddWithValue(eveningEntertainment);
                    cmd.Parameters.AddWithValue(kidsClub);
                    cmd.Parameters.AddWithValue(restaurant);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), (SizeEnum)reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetDecimal(4)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing combined search: {ex.Message}");
            }
            return rooms;
        }
    }
}
