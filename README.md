# nsb-sql-persistence-error

Demonstrates an issue with the SQL persister in NServiceBus.

## The problem

`GenericMessage` has a decimal property that is initialized to `decimal.MinValue` in the constructor. In the main application, we create an instance of this message and explicitly set the value of this property to 0 (the default for decimals). In the handler for this message, we copy these values over to the saga's data instance and write them out showing that they are set properly.

Next, we send another message in the saga. In the handler for this message, we again output the data for the saga instance and in this case, the value of the decimal property is set to `decimal.MinValue` rather than to 0 is we would expect.
