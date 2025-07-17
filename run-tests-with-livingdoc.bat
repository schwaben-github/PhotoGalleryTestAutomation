@echo off
dotnet test SpecFlowPhotoGallery.Specs
if exist SpecFlowPhotoGallery.Specs\bin\Debug\net8.0\TestExecution.json (
    livingdoc test-assembly SpecFlowPhotoGallery.Specs\bin\Debug\net8.0\SpecFlowPhotoGallery.Specs.dll -t SpecFlowPhotoGallery.Specs\bin\Debug\net8.0\TestExecution.json -o SpecFlowPhotoGallery.Specs\LivingDoc.html
    echo LivingDoc.html generated successfully.
) else (
    echo TestExecution.json not found. Make sure your tests ran and SpecFlow is configured to generate JSON results.
)
pause
