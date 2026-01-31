# Encryption API

A C# REST API for text encryption and decryption using Caesar Cipher, featuring a complete CI/CD pipeline with GitHub Actions and AWS Elastic Beanstalk deployment.

## Project Overview:

This project demonstrates a full CI/CD workflow for a .NET 8 Web API with automated testing, building, and deployment to AWS.

## Features:

- **Encryption Endpoint**: Encrypt text using Caesar Cipher
- **Decryption Endpoint**: Decrypt text encrypted with Caesar Cipher
- **RESTful API**: Clean API design with proper HTTP methods
- **CI/CD Pipeline**: Automated deployment using GitHub Actions
- **Unit Tests**: Comprehensive test coverage
- **AWS Deployment**: Hosted on AWS Elastic Beanstalk
- **Automated CI/CD**: GitHub Actions pipeline for testing and deployment

## Tech Stack:

- .NET 8
- ASP.NET Core Web API
- C#
- GitHub Actions
- AWS Elastic Beanstalk
- xUnit (for testing)

## API Endpoints

### Encrypt Text
```http
POST /api/encryption/encrypt
Content-Type: application/json

{
  "text": "Hello World",
  "shift": 3
}
```

**Response:**
```json
{
  "result": "Khoor Zruog"
}
```

### Decrypt Text
```http
POST /api/encryption/decrypt
Content-Type: application/json

{
  "text": "Khoor Zruog",
  "shift": 3
}
```

**Response:**
```json
{
  "result": "Hello World"
}
```

## Running Locally

1. Clone the repository:
```bash
git clone https://github.com/shiizuunee/Encryption-Api.git
cd Encryption-Api
```

2. Run the application:
```bash
dotnet run
```

3. Test the API:
```bash
curl -X POST http://localhost:5059/api/encryption/encrypt \
  -H "Content-Type: application/json" \
  -d '{"text":"Hello","shift":3}'
```

## Running Tests
```bash
dotnet test
```

## CI/CD Workflow

This project uses **Git Flow** branching strategy:

- `main` - Production-ready code
- `development` - Integration branch
- `feature/*` - Feature branches

All code is merged via Pull Requests with automated testing before deployment.

## Author:

**Djan Karis Lomongo Freolo**
- GitHub: [@shiizuunee](https://github.com/shiizuunee)

## License:
This project is created for educational purposes as part of a CI/CD course examination.