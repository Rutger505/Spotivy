using Spotivy;

List<Song> songs =
[
    new Song("Echoes of the Night", "Luna Nova", "Pop"),
    new Song("Journey to the Stars", "Stellar Dreams", "Electronic"),
    new Song("Whispers of the Wind", "Nature's Voice", "Ambient"),
    new Song("Rhythm of the Heart", "Beatz Crew", "Hip-Hop"),
    new Song("Serenade in Blue", "Jazz Masters", "Jazz")
];
List<Album> albums = new();
List<User> users =
[
    new User("Robert", [], []),
    new User("Rutger", [], []),
    new User("Sergio", [], []),
];

var client = new SpotivyClient(songs, albums, users);

client.SelectSong("Echoes of the Night");

client.SelectUser("Rutger");