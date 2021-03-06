﻿using System;
using Mantle.Extensions;
using Mantle.Interfaces;
using Mantle.Messaging.Constraints;
using Mantle.Messaging.Interfaces;

namespace Mantle.Messaging.Configurers
{
    public class DefaultSubscriptionConfigurer<T> : ISubscriptionConfigurer<T>
        where T : class
    {
        private readonly ISubscriptionConfiguration<T> configuration;

        public DefaultSubscriptionConfigurer(ISubscriptionConfiguration<T> configuration)
        {
            configuration.Require("configuration");
            this.configuration = configuration;
        }

        public void AddConstraint(ISubscriptionConstraint<T> constraint)
        {
            constraint.Require("constraint");
            configuration.Constraints.Add(constraint);
        }

        public void AddConstraint(Func<IMessageContext<T>, bool> condition)
        {
            condition.Require("condition");
            configuration.Constraints.Add(new FunctionalSubscriptionConstraint<T>(condition));
        }

        public void AddFilter(ISubscriptionFilter<T> filter)
        {
            filter.Require("filter");
            configuration.Filters.Add(filter);
        }

        public void DoAutoAbandon()
        {
            configuration.AutoAbandon = true;
        }

        public void DoAutoComplete()
        {
            configuration.AutoComplete = true;
        }

        public void DoAutoDeadLetter()
        {
            configuration.AutoDeadLetter = true;
        }

        public void DoNotAutoAbandon()
        {
            configuration.AutoAbandon = false;
        }

        public void DoNotAutoComplete()
        {
            configuration.AutoComplete = false;
        }

        public void DoNotAutoDeadLetter()
        {
            configuration.AutoDeadLetter = false;
        }

        public void SetDeadLetterDeliveryLimit(int deliveryLimit)
        {
            configuration.DeadLetterDeliveryLimit = deliveryLimit;
        }

        public void SetSubscriber(ISubscriber<T> subscriber)
        {
            subscriber.Require("subscriber");
            configuration.Subscriber = subscriber;
        }

        public void UseDeadLetterStrategy(IDeadLetterStrategy<T> deadLetterStrategy)
        {
            deadLetterStrategy.Require("deadLetterStrategy");
            configuration.DeadLetterStrategy = deadLetterStrategy;
        }

        public void UseSerializer(ISerializer<T> serializer)
        {
            serializer.Require("serializer");
            configuration.Serializer = serializer;
        }
    }
}