# Pre-Take0ff-Tasks

This repository contains solutions and explanations for a series of software design and development tasks, ranging from system design to programming exercises and theoretical concepts.

---

## **Task 1: Media Player System**

**Scenario:**  
Design a media player that can play audio files, video files, and live streams. Later, it might support podcasts and online radio.

**Instruction:**  
Write classes or modules for the media player system.


## **Task 2: Thermostat System**

**Scenario:**  
A thermostat controls the temperature and interacts with heaters and coolers. Other parts of the system might read or adjust the temperature. The system should remain reliable even if misused.

**Instruction:**  
Write a class or module for the Thermostat.


## **Task 3: Export System**

**Scenario:**  
A system needs to export reports in PDF, Excel, or CSV. Exported data can come from different services like sales, inventory, or user analytics.

**Instruction:**  
Write classes or modules for the export system.


## **Task 4: Co-variance & Contra-variance**

**Explanation:**  
- **Covariance:** Allows a more derived type than originally specified. Example: returning `IEnumerable<Derived>` when `IEnumerable<Base>` is expected.  
- **Contravariance:** Allows a more generic type than originally specified. Example: accepting `Action<Base>` where `Action<Derived>` is expected.  

---

## **Task 5: CSV User Creation System**

**Scenario:**  
Frontend submits a CSV with a list of users. Backend processes each user and creates them in auth-backend. After creation, backend triggers an email. Auth-backend can only process one user at a time.

**Instruction:**  
Write pseudocode for the system.


## **Task 6: Booking System**

**Scenario:**  
A simple booking system where many users can book only 100 seats.

**Instruction:**  
Write classes/modules to enforce seat limits.


## **Task 7: Result System for HSC & SSC**

**Scenario:**  
Design a result system for HSC & SSC in Bangladesh that can support nationwide concurrent access.

**Instruction:**  
Consider existing solutions, caching, and scaling.


## **Task 8: OAuth Client for Keycloak**

**Instruction:**  
Implement an OAuth client with authorization code flow.
 

---

## **Task 9: Tests for OAuth Implementation**

**Instruction:**  
Write unit/integration tests for OAuth client.

---

## **Task 10: Cost Projection Calculator**

**Scenario:**  
For the nationwide result system (Task 7), design a calculator to project costs according to request numbers, considering ready-made solutions and in-house components.
