# Para aplicar el principio de Information Expert, debíamos mover los métodos
# a las clases que tienen la información necesaria para cumplir con su responsabilidad.

from datetime import date

class Room:
    def __init__(self, room_number, room_type, price_per_night):
        self.room_number = room_number
        self.room_type = room_type
        self.price_per_night = price_per_night

class Guest:
    def __init__(self, guest_id, name, email):
        self.guest_id = guest_id
        self.name = name
        self.email = email

class Reservation:
    def __init__(self, reservation_id, guest, room, check_in_date, check_out_date):
        self.reservation_id = reservation_id
        self.guest = guest
        self.room = room
        self.check_in_date = check_in_date
        self.check_out_date = check_out_date

    def calculate_cost(self):
        """Calcula el costo total de la reserva basado en el número de noches."""
        nights = (self.check_out_date - self.check_in_date).days
        return self.room.price_per_night * nights

class Hotel:
    def __init__(self, name):
        self.name = name
        self.rooms = []
        self.reservations = []

    def find_available_rooms(self, check_in_date, check_out_date):
        """Busca habitaciones disponibles en el rango de fechas especificado."""
        reserved_rooms = set()
        for reservation in self.reservations:
            if not (reservation.check_out_date <= check_in_date or reservation.check_in_date >= check_out_date):
                reserved_rooms.add(reservation.room)
        return [room for room in self.rooms if room not in reserved_rooms]

# Crear un hotel
hotel = Hotel("Grand Hotel")

# Agregar habitaciones
room1 = Room(101, "Single", 100)
room2 = Room(102, "Double", 150)
hotel.rooms.extend([room1, room2])

# Crear un huésped
guest = Guest(1, "John Doe", "johndoe@example.com")

# Crear una reserva
reservation = Reservation(1, guest, room1, date(2025, 3, 10), date(2025, 3, 12))
hotel.reservations.append(reservation)

# Imprimir costo de la reserva
print(f"Costo de la reserva: ${reservation.calculate_cost()}")

# Buscar habitaciones disponibles
available_rooms = hotel.find_available_rooms(date(2025, 3, 10), date(2025, 3, 12))
print("Habitaciones disponibles:", [room.room_number for room in available_rooms])