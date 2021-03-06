For this scenario you have been hired to maintain and, if possible, expand  pre-existing code designed to manage a small library. The existing code is incomplete, and not necessarily correct. There are broken unit tests and code that does not adhere to Object Oriented Design principles. There is no documentation, and the former developer has fled the country. Your Product Owner has expressed that it is absolutely critical the code be able to perform the following functions in order to be considered viable.

 * Implement circulation limits such that patrons can have no more than:
  1. 10 adult fiction books at a time
  2. 5 compact discs at a time
  3. 30 picture books at a time (you'll need to implement a picture book class)
  4. All limits triple if the Patron is a school teacher
  5. A patron can have no more than 15 total items (teachers can have 50)

* Every item should have a title and description.
* If a Patron has had an item checked out beyond its maximum circulation time, they will not be allowed to check out additional items.

In addition to the mandatory features required, your Product Owner has created a list of highly requested features that would be nice additions, if possible. As the sole developer on the project it falls to you to decide which features will or won’t be implemented as part of the current iteration. Choose up to 2 features from the list to implement. Feel free to be define your own behaviors to support the features you choose, in addition or in place of those suggested. Please briefly explain your reasoning for prioritizing the features you’ve selected and the design decisions that went into your implementation.

######Feature 1 - The Library Catalog
	-The Library would like to track the items it owns via a central Catalog.
	-The catalog must track which items in its catalog are currently checked out.
	-The catalog will need to be searched and sorted in multiple useful ways.
	-The library would like to use the catalog to generate useful statistics.
	-The catalog may contain multiples of any given item.
######Feature 2 - Robust Item Information
	-Every item should have a unique identifier.
	-Product information for items may be gathered from a third party API. 
	-Existing search and sort abilities must take the expanded information into account.
	-Items that are not currently available must maintain a list of Patrons waiting to check them out.
######Feature 3 - Robust Patron Information
	-In addition to Teachers, Patrons may also be Adults or Children. 
	-A Teacher must be an Adult.
	-A Child must be linked to an Adult in order to check out items.
	-A Child cannot check out items classified as adult only.
######Feature 4 - Overdue Item Fines
	-Overdue items incur fines at a rate defined for each item type. 
	-A Patron owes fines based on the overdue items they currently have checked out.
	-A Patron cannot check out additional items while owing a fine.
	
Personal Notes: 

Overall I've strived to make much of the logic in the patron class. I considered (especially when the inventory grows) to create abstract classes that implement the Iitem interface to limit code in derived classes. i.e. one abstract book class for all categories of books. In the interface of Iitem I have added methods so it makes it easy for patron class to perform much of the logic with a view of one object type in order to use less reflection.

I've chosen to implement Features 3 and 4. I believe the service of feature 3 is something that is needed for the foundation of the software. Giving a blanket type to all patrons isn't ideal to me. The implementation of this feature has the Adult object as a dervied class of patron and Teacher is now a derived class of Adult. Having a teacher a derived class of an adult allows children being linked to easily. This idea would be extended if there are other special adult types. I have placed no constraints that multiple Child objects can be assigned to the same Adult. 

Feature 4 is implemented as it is important to hold those accountable for overdue books and generate income for a library. I had some debate as whether to implement feature 1 as statistics such as: How many books are checked out (and which ones)? How many times has an item has been checked out? This information would help improve inventory management. Of course searching for items would be easier. 


