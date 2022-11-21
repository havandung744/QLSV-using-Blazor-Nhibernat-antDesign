using BlazorInputFile;

namespace QLSV.Data.Service
{
    public interface IFileUpload
    {
        public Task UploadAsync(IFileListEntry file);
        public Task InputFile();

    }
}
