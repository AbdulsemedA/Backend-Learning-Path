namespace Task_2
{
    class MediaItem
    {
        public string Title { get; private set; }
        public string MediaType { get; private set; }
        public int Duration { get; private set; }

        public MediaItem(string title, string mediaType, int duration)
        {
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }
    }
}
