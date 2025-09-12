using MediaPlayerSytem;

Console.WriteLine("Started Media Player!");

IPlayableMedia audio = MediaFactory.Create(MediaType.Audio, "song.mp3", 240);
ISeekableMedia seekableAudio = audio as ISeekableMedia;

audio.Play();
seekableAudio?.FastForward();
audio.Pause();
audio.Stop();

Console.WriteLine("______________________\n");

IPlayableMedia video = MediaFactory.Create(MediaType.Video, "movie.mp4", 1200);
ISeekableMedia seekableVideo = video as ISeekableMedia;

video.Play();
seekableVideo?.Rewind();
video.Pause();
video.Stop();

Console.WriteLine("______________________\n");

IPlayableMedia podcast = MediaFactory.Create(MediaType.Podcast, "http://podcast.com/episode1", 1800);
ISeekableMedia seekablePodcast = podcast as ISeekableMedia;

podcast.Play();
seekablePodcast?.FastForward();
podcast.Pause();
podcast.Stop();

Console.WriteLine("______________________\n");

IPlayableMedia liveStream = MediaFactory.Create(MediaType.LiveStream, "http://live.example.com");
liveStream.Play();
liveStream.Pause();
liveStream.Stop();

Console.WriteLine("______________________\n");

IPlayableMedia radio = MediaFactory.Create(MediaType.Radio, "http://radio.example.com");
radio.Play();
radio.Pause();
radio.Stop();
