# BowlingScorer

A console-based C# application for calculating bowling scores, designed with proper code structure, class separation, and industry best practices.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Usage](#usage)
  - [Gameplay Instructions](#gameplay-instructions)
  - [Scoring Rules](#scoring-rules)
- [Code Structure](#code-structure)
  - [Class Overview](#class-overview)
- [Testing](#testing)
  - [Running Unit Tests](#running-unit-tests)
- [Contact](#contact)
- [Future Enhancements](#future-enhancements)

---

## Introduction

**BowlingScorer** is a fully-featured application that simulates scoring in a standard ten-pin bowling game. The program allows users to input rolls frame by frame and calculates the total score according to official bowling rules, including strikes, spares, and bonus rolls in the tenth frame.

This project emphasizes clean code architecture, utilizing object-oriented principles and design patterns to ensure code readability, maintainability, and extensibility.

---

## Features

- **Interactive Gameplay:** Input scores for each roll through the console interface.
- **Accurate Scoring:** Implements standard bowling scoring rules, including strikes, spares, and bonus calculations.
- **Input Validation:** Ensures all user inputs are within valid ranges, providing prompts for corrections.
- **Comprehensive Testing:** Includes unit tests for all public methods using MSTest, ensuring code reliability.
- **Clean Code Structure:** Follows industry best practices with proper class separation and method encapsulation.

---

## Getting Started

### Prerequisites

- **.NET SDK 6.0 or later**: [Download here](https://dotnet.microsoft.com/download).
- **Git**: For cloning the repository. [Download here](https://git-scm.com/downloads).
- **IDE (optional but recommended):** Visual Studio 2022, Visual Studio Code, or any C# compatible IDE.

### Installation

1. **Clone the Repository**

   Open your terminal or command prompt and run:

   ```bash
   git clone https://github.com/arunsasankan/BowlingScorer.git

### Running the Application

You can run the application using the .NET CLI or through your preferred IDE.

**Using .NET CLI:**

bash

```
dotnet run --project BowlingScorer

```

**Using Visual Studio:**

-   Open the `BowlingScorer.sln` solution file.
    
-   Set `BowlingScorer` as the startup project.
    
-   Press **F5** to run the application.
    

## Usage

### Gameplay Instructions

1.  **Start the Game**
    
    Run the application to begin a new bowling game.
    
2.  **Input Rolls**
    
    -   The game consists of 10 frames.
        
    -   For each frame, you'll be prompted to enter the number of pins knocked down on the first roll.
        
    -   If you knock down all 10 pins on the first roll (a strike), the frame ends, and you proceed to the next frame.
        
    -   If you knock down fewer than 10 pins, you'll be prompted for a second roll.
        
3.  **Bonus Rolls**
    
    -   In the 10th frame, if you roll a strike or spare, you'll be granted bonus rolls according to bowling rules.
        
    -   Follow the prompts to enter your bonus roll scores.
        
4.  **Score Calculation**
    
    -   After all frames have been completed, the program will calculate and display your total score.
        

### Scoring Rules

-   **Strike (X):**
    
    -   Occurs when you knock down all 10 pins on the first roll.
        
    -   Score for the frame = 10 + sum of the next two rolls.
        
-   **Spare (/):**
    
    -   Occurs when you knock down all remaining pins on the second roll.
        
    -   Score for the frame = 10 + pins knocked down in the next roll.
        
-   **Open Frame:**
    
    -   When fewer than 10 pins are knocked down after two rolls.
        
    -   Score for the frame = total pins knocked down in the frame.
        
-   **10th Frame Special Rules:**
    
    -   If you roll a strike in the 10th frame, you get two additional bonus rolls.
        
    -   If you roll a spare in the 10th frame, you get one additional bonus roll.
        

## Code Structure

### Class Overview

-   **BowlingGame**
    
    -   Manages the overall game logic, including reading input, adding frames, handling bonus rolls, and calculating the total score.
        
-   **Frame**
    
    -   Represents a single frame in the game.
        
    -   Encapsulates roll information and determines if the frame is a strike or spare.
        
    -   Calculates the frame score, including bonuses.
        
-   **Program**
    
    -   The entry point of the application.
        
    -   Initializes the game and starts the data reading process.
        

## Testing

The project includes comprehensive unit tests covering all public methods in the `BowlingGame` class using **MSTest**.

### Running Unit Tests

1.  **Navigate to the Test Project Directory**
    
    bash
    
    ```
    cd BowlingScorer.Tests
    
    ```
    
2.  **Run Tests**
    
    bash
    
    ```
    dotnet test
    
    ```
    
    This will execute all tests and display the results, ensuring that all game logic performs as expected.
    

## Contact

-   **Author:** Arun Sasankan
    
-   **GitHub:** arunsasankan
    
-   **Email:** arunsasankan@example.com


## Future Enhancements

-   **Graphical User Interface (GUI):** Develop a UI using WPF or Windows Forms for a more interactive experience.
    
-   **Multiplayer Support:** Extend the application to handle multiple players in a single game.
    
-   **Advanced Scoring Features:** Implement additional game modes or alternative scoring systems.
    
