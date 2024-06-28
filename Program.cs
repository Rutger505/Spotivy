using Spotivy;

List<Song> songs =
[
    new Song("Echoes of the Night", "Luna Nova", "Pop"),
    new Song("Journey to the Stars", "Stellar Dreams", "Electronic"),
    new Song("Whispers of the Wind", "Nature's Voice", "Ambient"),
    new Song("Rhythm of the Heart", "Beatz Crew", "Hip-Hop"),
    new Song("Serenade in Blue", "Jazz Masters", "Jazz")
];
List<Album> albums =
[
    new Album("Jasper Valley", "Luna Nova", "Pop", [songs[0], songs[3], songs[4]]),
    new Album("Galactic Odyssey", "Stellar Dreams", "Electronic", [songs[1], songs[2]]),
    new Album("Nature's Symphony", "Nature's Voice", "Ambient", [songs[2]]),
];
List<User> users =
[
    new User("Robert", [
        new Playlist("Meaty metal", "Robert", [
            songs[2],
            songs[3]
        ]),
    ], []),
    new User("Rutger", [
        new Playlist("Favorites", "Rutger", [
            songs[0],
            songs[1],
            songs[2]
        ]),
    ], []),
    new User("Sergio", [], []),
];

var client = new SpotivyClient(songs, albums, users, users[1]);

client.SelectSong("Echoes of the Night");

client.AddToPlaylist("Favorites");

client.SelectPlaylist("Favorites");

client.ViewDetails();

client.RemoveSongFromSelectedPlaylist("Echoes of the Night");
client.RemoveSongFromSelectedPlaylist("Whispers of the Wind");
client.RemoveSongFromSelectedPlaylist("Rhythm of the Heart");