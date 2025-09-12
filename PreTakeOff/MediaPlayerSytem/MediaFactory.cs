namespace MediaPlayerSytem
{
    public static class MediaFactory
    {
        public static IPlayableMedia Create(MediaType type, string source, int duration = 0)
        {
            return type switch
            {
                MediaType.Audio => new AudioFile(source, duration),
                MediaType.Video => new VideoFile(source, duration),
                MediaType.Podcast => new Podcast(source, duration),
                MediaType.LiveStream => new LiveStream(source),
                MediaType.Radio => new OnlineRadio(source),
                _ => throw new ArgumentException("Invalid media type")
            };
        }
    }
}
